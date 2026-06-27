import axios from 'axios';

/**
 * Pre-configured Axios instance for FinPilot AI backend API.
 * Includes base URL, default headers, timeout, and interceptors.
 */
const apiClient = axios.create({
  baseURL: process.env.NEXT_PUBLIC_API_URL || 'http://localhost:5000/api',
  timeout: 30000,
  headers: {
    'Content-Type': 'application/json',
    Accept: 'application/json',
  },
});

// Request interceptor — attach auth token (future Phase 2)
apiClient.interceptors.request.use(
  (config) => {
    // Token will be added in Phase 2 (Authentication)
    // const token = getAuthToken();
    // if (token) {
    //   config.headers.Authorization = `Bearer ${token}`;
    // }
    return config;
  },
  (error) => Promise.reject(error)
);

// Response interceptor — handle common errors
apiClient.interceptors.response.use(
  (response) => response,
  (error) => {
    if (error.response) {
      switch (error.response.status) {
        case 401:
          // Handle unauthorized — redirect to login (Phase 2)
          break;
        case 403:
          // Handle forbidden
          break;
        case 500:
          // Handle server error
          console.error('Server error:', error.response.data);
          break;
      }
    }
    return Promise.reject(error);
  }
);

export default apiClient;
