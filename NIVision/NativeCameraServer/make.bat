arm-frc-linux-gnueabi-gcc -fPIC priority_mutex.cpp NativeCameraServer.cpp USBCamera.cpp -std=c++1y -shared -o libcameraserver.so -O2