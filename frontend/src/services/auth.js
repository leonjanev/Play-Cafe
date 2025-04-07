import axios from 'axios';

const API_URL = 'https://localhost:8000/api';

export const login = async (credentials) => {
  try {
    const response = await axios.post(`${API_URL}/account/login`, credentials);
    return response.data; // Return the raw response data
  } catch (error) {
    console.error('Login error:', error.response?.data);
    throw error;
  }
};

export const register = async (userData) => {
  try {
    const registerData = {
      fullName: `${userData.firstName} ${userData.lastName}`.trim(),
      email: userData.email,
      password: userData.password,
      confirmPassword: userData.confirmPassword
    };
    
    const response = await axios.post(`${API_URL}/account/register`, registerData);
    return response.data;
  } catch (error) {
    console.error('Register error:', error.response?.data);
    throw error;
  }
};

export const logout = () => {
  localStorage.removeItem('accessToken');
  localStorage.removeItem('refreshToken');
  localStorage.removeItem('user');
};

export const isAuthenticated = () => {
  const token = localStorage.getItem('accessToken');
  if (!token) return false;
  
  try {
    const user = parseJwt(token);
    const isExpired = user.exp * 1000 < Date.now();
    
    if (isExpired) {
      logout();
      return false;
    }
    
    return true;
  } catch (e) {
    logout();
    return false;
  }
};

export const isAdmin = () => {
  try {
    const token = localStorage.getItem('accessToken');
    if (!token) return false;
    
    const user = parseJwt(token);
    return user.role === 'Admin';
  } catch (e) {
    return false;
  }
};

const parseJwt = (token) => {
  try {
    return JSON.parse(atob(token.split('.')[1]));
  } catch (e) {
    return null;
  }
}; 