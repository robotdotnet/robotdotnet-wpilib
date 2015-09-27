﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HAL_Simulator.Annotations;

namespace HAL_Simulator.Data
{
    public enum TrigerType
    {
        Filtered,
        Averaged,
        Unassigned
    }

    public class AnalogTriggerData : DataBase
    {
        private bool m_hasSource = false;
        private bool m_initialized = false;
        private int m_pin = -1;
        private long m_pointer = 0;
        private TrigerType m_trigType = TrigerType.Unassigned;
        private bool m_trigState = false;
        private double m_trigUpper = 0;
        private double m_trigLower = 0;

        public override void ResetData()
        {
            m_hasSource = false;
            m_initialized = false;
            m_pin = -1;
            m_pointer = 0;
            m_trigType = TrigerType.Unassigned;
            m_trigState = false;
            m_trigUpper = 0;
            m_trigLower = 0;
        }

        public bool HasSource
        {
            get { return m_hasSource; }
            set
            {
                if (value == m_hasSource) return;
                m_hasSource = value;
                OnPropertyChanged(value);
            }
        }

        public bool Initialized
        {
            get { return m_initialized; }
            set
            {
                if (value == m_initialized) return;
                m_initialized = value;
                OnPropertyChanged(value);
            }
        }

        public int Pin
        {
            get { return m_pin; }
            set
            {
                if (value == m_pin) return;
                m_pin = value;
                OnPropertyChanged(value);
            }
        }

        public long Pointer
        {
            get { return m_pointer; }
            set
            {
                if (value == m_pointer) return;
                m_pointer = value;
                OnPropertyChanged(value);
            }
        }

        public TrigerType TrigType
        {
            get { return m_trigType; }
            set
            {
                if (value == m_trigType) return;
                m_trigType = value;
                OnPropertyChanged(value);
            }
        }

        public bool TrigState
        {
            get { return m_trigState; }
            set
            {
                if (value == m_trigState) return;
                m_trigState = value;
                OnPropertyChanged(value);
            }
        }

        public double TrigUpper
        {
            get { return m_trigUpper; }
            set
            {
                if (value.Equals(m_trigUpper)) return;
                m_trigUpper = value;
                OnPropertyChanged(value);
            }
        }

        public double TrigLower
        {
            get { return m_trigLower; }
            set
            {
                if (value.Equals(m_trigLower)) return;
                m_trigLower = value;
                OnPropertyChanged(value);
            }
        }
    }
}
