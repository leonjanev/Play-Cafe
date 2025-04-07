import axios from 'axios';

const API_URL = 'https://localhost:8000/api';

// Add error handling helper
const handleApiError = (error, operation) => {
  console.error(`Error in ${operation}:`, error.response?.data || error.message);
  throw error;
};

// Products API
export const fetchProducts = async () => {
  try {
    const response = await axios.get(`${API_URL}/product`);
    return response.data;
  } catch (error) {
    handleApiError(error, 'fetchProducts');
  }
};

export const fetchProductById = async (id) => {
  try {
    const response = await axios.get(`${API_URL}/product/${id}`);
    return response.data;
  } catch (error) {
    handleApiError(error, 'fetchProductById');
  }
};

export const fetchProductsBySubCategory = async (subCategoryId) => {
  try {
    const response = await axios.get(`${API_URL}/product/subcategory/${subCategoryId}`);
    return response.data;
  } catch (error) {
    handleApiError(error, 'fetchProductsBySubCategory');
  }
};

export const createProduct = async (product) => {
  try {
    const response = await axios.post(`${API_URL}/product`, {
      ...product
    });
    return response.data;
  } catch (error) {
    handleApiError(error, 'createProduct');
  }
};

export const updateProduct = async (id, product) => {
  try {
    const response = await axios.put(`${API_URL}/product/${id}`, {
      ...product,
      id: parseInt(id)
    });
    return response.data;
  } catch (error) {
    handleApiError(error, 'updateProduct');
  }
};

export const deleteProduct = async (id) => {
  try {
    await axios.delete(`${API_URL}/product/${id}`);
  } catch (error) {
    handleApiError(error, 'deleteProduct');
  }
};

export const updateProductAvailability = async (id, isAvailable) => {
  try {
    await axios.patch(`${API_URL}/product/${id}/availability`, isAvailable);
  } catch (error) {
    handleApiError(error, 'updateProductAvailability');
  }
};

// Categories API
export const fetchCategories = async () => {
  try {
    const response = await axios.get(`${API_URL}/category`);
    return response.data;
  } catch (error) {
    handleApiError(error, 'fetchCategories');
  }
};

export const fetchCategoryById = async (id) => {
  try {
    const response = await axios.get(`${API_URL}/category/${id}`);
    return response.data;
  } catch (error) {
    handleApiError(error, 'fetchCategoryById');
  }
};

export const createCategory = async (category) => {
  try {
    const response = await axios.post(`${API_URL}/category`, category);
    return response.data;
  } catch (error) {
    handleApiError(error, 'createCategory');
  }
};

export const updateCategory = async (id, category) => {
  try {
    const response = await axios.put(`${API_URL}/category/${id}`, {
      ...category,
      id: parseInt(id)
    });
    return response.data;
  } catch (error) {
    handleApiError(error, 'updateCategory');
  }
};

export const deleteCategory = async (id) => {
  try {
    await axios.delete(`${API_URL}/category/${id}`);
  } catch (error) {
    handleApiError(error, 'deleteCategory');
  }
};

// Subcategories API
export const fetchSubcategories = async () => {
  try {
    const response = await axios.get(`${API_URL}/subcategory`);
    return response.data;
  } catch (error) {
    handleApiError(error, 'fetchSubcategories');
  }
};

export const fetchSubcategoriesByCategory = async (categoryId) => {
  try {
    const response = await axios.get(`${API_URL}/subcategory/category/${categoryId}`);
    return response.data;
  } catch (error) {
    handleApiError(error, 'fetchSubcategoriesByCategory');
  }
};

export const fetchSubcategoryById = async (id) => {
  try {
    const response = await axios.get(`${API_URL}/subcategory/${id}`);
    return response.data;
  } catch (error) {
    handleApiError(error, 'fetchSubcategoryById');
  }
};

export const createSubcategory = async (subcategory) => {
  try {
    const response = await axios.post(`${API_URL}/subcategory`, {
      ...subcategory     
    });
    return response.data;
  } catch (error) {
    handleApiError(error, 'createSubcategory');
  }
};

export const updateSubcategory = async (id, subcategory) => {
  try {
    const response = await axios.put(`${API_URL}/subcategory/${id}`, {
      ...subcategory,
      id: parseInt(id)      
    });
    return response.data;
  } catch (error) {
    handleApiError(error, 'updateSubcategory');
  }
};

export const deleteSubcategory = async (id) => {
  try {
    await axios.delete(`${API_URL}/subcategory/${id}`);
  } catch (error) {
    handleApiError(error, 'deleteSubcategory');
  }
};

// Add axios interceptors for common headers and error handling
axios.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem('accessToken');
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    config.headers['Content-Type'] = 'application/json';
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

axios.interceptors.response.use(
  (response) => response,
  async (error) => {
    if (error.response?.status === 401) {
      // Clear all auth data and redirect to login
      localStorage.removeItem('accessToken');
      localStorage.removeItem('refreshToken');
      localStorage.removeItem('user');
      localStorage.removeItem('token');
      window.location.href = '/login';
    }
    return Promise.reject(error);
  }
);

export const fetchProductsByCategory = async (categoryId) => {
  try {
    // Get subcategories for this category first
    const subcategories = await fetchSubcategoriesByCategory(categoryId);
    
    if (!Array.isArray(subcategories) || subcategories.length === 0) {
      return [];
    }

    // Get products for each subcategory
    const productsPromises = subcategories.map(sub => 
      fetchProductsBySubCategory(sub.id)
    );

    const productsArrays = await Promise.all(productsPromises);
    
    // Flatten the array of arrays into a single array of products
    const products = productsArrays.flat().filter(Boolean);
    
    return products;
  } catch (error) {
    console.error('Error in fetchProductsByCategory:', error);
    return [];
  }
}; 