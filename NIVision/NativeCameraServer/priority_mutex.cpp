#include "priority_mutex.h"

void priority_recursive_mutex::lock() {
  pthread_mutex_lock(&m_mutex);
}

void priority_recursive_mutex::unlock() {
  pthread_mutex_unlock(&m_mutex);
}

bool priority_recursive_mutex::try_lock() noexcept {
  return !pthread_mutex_trylock(&m_mutex);
}

pthread_mutex_t* priority_recursive_mutex::native_handle() {
  return &m_mutex;
}

void priority_mutex::lock() {
  pthread_mutex_lock(&m_mutex);
}

void priority_mutex::unlock() {
  pthread_mutex_unlock(&m_mutex);
}

bool priority_mutex::try_lock() noexcept {
  return !pthread_mutex_trylock(&m_mutex);
}

pthread_mutex_t* priority_mutex::native_handle() {
  return &m_mutex;
}
