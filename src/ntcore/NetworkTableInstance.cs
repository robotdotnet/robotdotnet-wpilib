// Copyright (c) FIRST and other WPILib contributors.
// Open Source Software; you can modify and/or share it under the terms of
// the WPILib BSD license file in the root directory of this project.

// THIS FILE WAS AUTO-GENERATED BY ./ntcore/generate_topics.py. DO NOT MODIFY

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using NetworkTables.Handles;
using NetworkTables.Natives;
using WPIMath.Geometry;
using WPIUtil;
using WPIUtil.Concurrent;
using WPIUtil.Natives;
using WPIUtil.Serialization.Protobuf;

namespace NetworkTables;

/**
 * NetworkTables Instance.
 *
 * <p>Instances are completely independent from each other. Table operations on one instance will
 * not be visible to other instances unless the instances are connected via the network. The main
 * limitation on instances is that you cannot have two servers on the same network port. The main
 * utility of instances is for unit testing, but they can also enable one program to connect to two
 * different NetworkTables networks.
 *
 * <p>The global "default" instance (as returned by {@link #GetDefault()}) is always available, and
 * is intended for the common case when there is only a single NetworkTables instance being used in
 * the program.
 *
 * <p>Additional instances can be created with the {@link #create()} function. A reference must be
 * kept to the NetworkTableInstance returned by this function to keep it from being garbage
 * collected.
 */
public sealed partial class NetworkTableInstance : IDisposable, IEquatable<NetworkTableInstance?>
{
    public const int KDefaultPort3 = 1735;
    public const int KDefaultPort4 = 5810;

    private NetworkTableInstance() : this(NtCore.GetDefaultInstance(), false) { }

    private NetworkTableInstance(NtInst inst, bool owned)
    {
        Handle = inst;
        m_owned = owned;
        m_listeners = new(this);
    }

    public NtInst Handle { get; private set; }

    private readonly bool m_owned;

    public void Dispose()
    {
        if (m_owned & Handle.Handle != 0)
        {
            NtCore.DestroyInstance(Handle);
            Handle = default;
        }
    }

    public bool IsValid => Handle.Handle != 0;

    private static readonly Lazy<NetworkTableInstance> s_defaultInstance = new();

    public static NetworkTableInstance Default => s_defaultInstance.Value;

    public static NetworkTableInstance Create()
    {
        return new(NtCore.CreateInstance(), true);
    }

    public Topic GetTopic(string name)
    {
        Topic topic = m_topics.GetOrAdd(name, n =>
        {
            NtTopic topicHandle = NtCore.GetTopic(Handle, name);
            Topic topic = new(this, topicHandle);
            m_topicsByHandle.TryAdd(topicHandle, topic);
            return topic;
        });
        return topic;
    }

    private Topic[] TopicHandlesToTopics(NtTopic[] handles)
    {
        Topic[] topics = new Topic[handles.Length];
        for (int i = 0; i < handles.Length; i++)
        {
            topics[i] = GetCachedTopic(handles[i]);
        }
        return topics;
    }

    internal Topic GetCachedTopic(NtTopic handle)
    {
        Topic topic = m_topicsByHandle.GetOrAdd(handle, n =>
                {
                    Topic topic = new(this, handle);
                    return topic;
                });
        return topic;
    }

    public Topic[] GetTopics()
    {
        return TopicHandlesToTopics(NtCore.GetTopics(Handle, "", NetworkTableType.Unassigned));
    }

    public Topic[] GetTopics(string prefix)
    {
        return TopicHandlesToTopics(NtCore.GetTopics(Handle, prefix, NetworkTableType.Unassigned));
    }

    public Topic[] GetTopics(string prefix, NetworkTableType types)
    {
        return TopicHandlesToTopics(NtCore.GetTopics(Handle, prefix, types));
    }

    public Topic[] GetTopics(string prefix, string[] types)
    {
        return TopicHandlesToTopics(NtCore.GetTopics(Handle, prefix, types));
    }

    public TopicInfo[] GetTopicInfo()
    {
        return NtCore.GetTopicInfos(Handle, "", NetworkTableType.Unassigned);
    }

    public TopicInfo[] GetTopicInfo(string prefix)
    {
        return NtCore.GetTopicInfos(Handle, prefix, NetworkTableType.Unassigned);
    }

    public TopicInfo[] GetTopicInfo(string prefix, NetworkTableType types)
    {
        return NtCore.GetTopicInfos(Handle, prefix, types);
    }

    public TopicInfo[] GetTopicInfo(string prefix, string[] types)
    {
        return NtCore.GetTopicInfos(Handle, prefix, types);
    }

    private class ListenerStorage(NetworkTableInstance inst) : IDisposable
    {
        private readonly object m_lock = new();
        private readonly Dictionary<NtListener, Action<NetworkTableEvent>> m_listeners = new();
        private Thread? m_thread;
        private NtListenerPoller m_poller;
        private bool m_waitQueue;
        private readonly Event m_waitQueueEvent = new();
        private readonly NetworkTableInstance m_inst = inst;

        public NtListener Add(string[] prefixes, EventFlags eventKinds, Action<NetworkTableEvent> listener)
        {
            lock (m_lock)
            {
                if (m_poller.Handle == 0)
                {
                    m_poller = NtCore.CreateListenerPoller(m_inst.Handle);
                    StartThread();
                }
                NtListener h = NtCore.AddListener(m_poller, prefixes, eventKinds);
                m_listeners.Add(h, listener);
                return h;
            }
        }

        public NtListener Add(NtInst handle, EventFlags eventKinds, Action<NetworkTableEvent> listener)
        {
            lock (m_lock)
            {
                if (m_poller.Handle == 0)
                {
                    m_poller = NtCore.CreateListenerPoller(m_inst.Handle);
                    StartThread();
                }
                NtListener h = NtCore.AddListener(m_poller, handle, eventKinds);
                m_listeners.Add(h, listener);
                return h;
            }
        }

        public NtListener Add<T>(T handle, EventFlags eventKinds, Action<NetworkTableEvent> listener) where T : struct, INtEntryHandle
        {
            lock (m_lock)
            {
                if (m_poller.Handle == 0)
                {
                    m_poller = NtCore.CreateListenerPoller(m_inst.Handle);
                    StartThread();
                }
                NtListener h = NtCore.AddListener(m_poller, handle, eventKinds);
                m_listeners.Add(h, listener);
                return h;
            }
        }

        public void Remove(NtListener listener)
        {
            lock (m_lock)
            {
                m_listeners.Remove(listener);
            }
            NtCore.RemoveListener(listener);
        }

        public void Dispose()
        {
            if (m_poller.Handle != 0)
            {
                NtCore.DestroyListenerPoller(m_poller);
                m_poller = default;
            }
        }

        private void StartThread()
        {
            m_thread = new Thread(() =>
            {
                bool wasInterrupted = false;
                ReadOnlySpan<int> handles = [m_poller.Handle, m_waitQueueEvent.Handle];
                Span<int> signaledStorage = [0, 0];
                while (true)
                {
                    var signaled = SynchronizationNative.WaitForObjects(handles, signaledStorage);
                    if (signaled.Length == 0)
                    {
                        lock (m_lock)
                        {
                            if (m_waitQueue)
                            {
                                m_waitQueue = false;
                                Monitor.PulseAll(m_lock);
                            }
                        }
                        wasInterrupted = true;
                        break;
                    }
                    foreach (NetworkTableEvent evnt in NtCore.ReadListenerQueue(m_poller))
                    {
                        Action<NetworkTableEvent>? listener;
                        lock (m_lock)
                        {
                            if (!m_listeners.TryGetValue(evnt.ListenerHandle, out listener))
                            {
                                listener = null;
                            }
                        }
                        try
                        {
                            listener?.Invoke(evnt);
                        }
                        catch (Exception ex)
                        {
                            Console.Error.WriteLine($"Unhandled exception during listener callback: {ex}");
                        }
                    }
                    lock (m_lock)
                    {
                        if (m_waitQueue)
                        {
                            m_waitQueue = false;
                            Monitor.PulseAll(m_lock);
                        }
                    }
                }
                lock (m_lock)
                {
                    if (!wasInterrupted)
                    {
                        NtCore.DestroyListenerPoller(m_poller);
                    }
                    m_poller = default;
                }

            })
            {
                Name = "NTListener",
                IsBackground = true
            };
            m_thread.Start();
        }

        public bool WaitForQueue(TimeSpan? timeout)
        {
            lock (m_lock)
            {
                if (m_poller.Handle != 0)
                {
                    m_waitQueue = true;
                    m_waitQueueEvent.Set();
                }
                while (m_waitQueue)
                {
                    if (!timeout.HasValue)
                    {
                        Monitor.Wait(m_lock);
                    }
                    else
                    {
                        return Monitor.Wait(m_lock, timeout.Value);
                    }
                }
            }
            return true;
        }
    }

    private readonly ListenerStorage m_listeners;

    public void RemoveListener(NtListener listener)
    {
        m_listeners.Remove(listener);
    }

    public bool WaitForListenerQueue(TimeSpan? timeout)
    {
        return m_listeners.WaitForQueue(timeout);
    }

    public NtListener AddConnectionListener(bool immediateNotify, Action<NetworkTableEvent> listener)
    {
        EventFlags flags = EventFlags.Connection;
        if (immediateNotify)
        {
            flags |= EventFlags.Immediate;
        }
        return m_listeners.Add(Handle, flags, listener);
    }

    public NetworkMode GetNetworkMode()
    {
        return NtCore.GetNetworkMode(Handle);
    }

    public void StartLocal()
    {
        NtCore.StartLocal(Handle);
    }

    public void StopLocal()
    {
        NtCore.StopLocal(Handle);
    }

    public void StartServer(string persistFilename = "networktables.json", string listenAddress = "", int port3 = KDefaultPort3, int port4 = KDefaultPort4)
    {
        NtCore.StartServer(Handle, persistFilename, listenAddress, (uint)port3, (uint)port4);
    }

    public void StopServer()
    {
        NtCore.StopServer(Handle);
    }

    public void StartClient3(string identity)
    {
        NtCore.StartClient3(Handle, identity);
    }

    public void StartClient4(string identity)
    {
        NtCore.StartClient4(Handle, identity);
    }

    public void SetServer(string serverName, int port = 0)
    {
        NtCore.SetServer(Handle, serverName, (uint)port);
    }

    public void SetServer(params string[] serverNames)
    {
        SetServer(serverNames, 0);
    }

    public void SetServer(ReadOnlySpan<string> serverNames, int port)
    {
        Span<int> ports = stackalloc int[16];
        if (serverNames.Length > 16)
        {
            ports = new int[serverNames.Length];
        }
        else
        {
            ports = ports[..serverNames.Length];
        }

        ports.Fill(port);
        SetServer(serverNames, ports);
    }

    public void SetServer(ReadOnlySpan<string> serverNames, ReadOnlySpan<int> ports)
    {
        NtCore.SetServerMulti(Handle, serverNames, MemoryMarshal.Cast<int, uint>(ports));
    }

    public void SetServerTeam(int team, int port = 0)
    {
        NtCore.SetServerTeam(Handle, (uint)team, (uint)port);
    }

    public void Disconnect()
    {
        NtCore.Disconnect(Handle);
    }

    public void StartDsClient(int port = 0)
    {
        NtCore.StartDSClient(Handle, (uint)port);
    }

    public void StopDsClient()
    {
        NtCore.StopDSClient(Handle);
    }

    public void FlushLLocal()
    {
        NtCore.FlushLocal(Handle);
    }

    public void Flush()
    {
        NtCore.Flush(Handle);
    }

    public ConnectionInfo[] GetConnections()
    {
        return NtCore.GetConnections(Handle);
    }

    public bool Connected => NtCore.IsConnected(Handle);

    public long? ServerTimeOffset => NtCore.GetServerTimeOffset(Handle);

    public unsafe NtDataLogger StartEntryDataLog(DataLog log, string prefix, string logPrefix)
    {
        return NtCore.StartEntryDataLog(Handle, log.NativeHandle, prefix, logPrefix);
    }

    public static void StopEntryDataLog(NtDataLogger logger)
    {
        NtCore.StopEntryDataLog(logger);
    }

    public unsafe NtConnectionDataLogger StartConnectionDataLog(DataLog log, string name)
    {
        return NtCore.StartConnectionDataLog(Handle, log.NativeHandle, name);
    }

    public static void StopConnectionDataLog(NtConnectionDataLogger logger)
    {
        NtCore.StopConnectionDataLog(logger);
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as NetworkTableInstance);
    }

    public bool Equals(NetworkTableInstance? other)
    {
        return other is not null &&
               Handle == other.Handle;
    }

    public override int GetHashCode()
    {
        return Handle.GetHashCode();
    }

    private readonly ConcurrentDictionary<string, Topic> m_topics = new();
    private readonly ConcurrentDictionary<NtTopic, Topic> m_topicsByHandle = new();

    public static bool operator ==(NetworkTableInstance? left, NetworkTableInstance? right)
    {
        return EqualityComparer<NetworkTableInstance>.Default.Equals(left, right);
    }

    public static bool operator !=(NetworkTableInstance? left, NetworkTableInstance? right)
    {
        return !(left == right);
    }

    public void AddSchema(IProtobufBase proto)
    {
        throw new NotImplementedException();
    }

    public ProtobufTopic<T> GetProtobufTopic<T>(string name) where T : IProtobufSerializable<T>
    {

        GetProtobufTopic<Rotation2d>("Hello");
        throw new NotImplementedException();
    }
}
