import { Link, useLocation } from 'react-router-dom';
import { useState, useEffect } from 'react';
import { fetchCategories } from '../../services/api';
import { isAuthenticated, logout } from '../../services/auth';

const CustomerLayout = ({ children }) => {
  const [categories, setCategories] = useState([]);
  const [loading, setLoading] = useState(true);
  const location = useLocation();
  const isLoggedIn = isAuthenticated();

  useEffect(() => {
    const loadCategories = async () => {
      try {
        const data = await fetchCategories();
        setCategories(data);
      } catch (error) {
        console.error('Error loading categories:', error);
      } finally {
        setLoading(false);
      }
    };
    loadCategories();
  }, []);

  const handleLogout = () => {
    logout();
    window.location.href = '/login';
  };

  const isActiveCategory = (categoryId) => {
    return location.pathname === `/category/${categoryId}`;
  };

  return (
    <div className="min-h-screen bg-gray-50 flex flex-col">
      <nav className="bg-white shadow-lg">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="flex justify-between h-16">
            <div className="flex-1 flex items-center justify-center sm:justify-start">
              <div className="flex-shrink-0">
                <Link to="/" className="text-2xl font-bold">
                  <span className="text-primary-500">Play</span>
                  <span className="text-secondary-500">Cafe</span>
                </Link>
              </div>
              <div className="hidden sm:flex sm:space-x-8 sm:ml-6 sm:flex-1 sm:justify-center">
                {categories.map(category => (
                  <Link
                    key={category.id}
                    to={`/category/${category.id}`}
                    className={`inline-flex items-center px-1 pt-1 text-sm font-medium
                      ${isActiveCategory(category.id)
                        ? 'border-b-2 border-primary-500 text-primary-600'
                        : 'text-gray-900 hover:text-primary-600'
                      }`}
                  >
                    {category.name}
                  </Link>
                ))}
              </div>
            </div>
            <div className="flex items-center space-x-4">
              {isLoggedIn ? (
                <button
                  onClick={handleLogout}
                  className="inline-flex items-center px-4 py-2 border border-transparent text-sm font-medium rounded-md text-white bg-primary-500 hover:bg-primary-600"
                >
                  Logout
                </button>
              ) : (
                <>
                  <Link
                    to="/login"
                    className="text-sm font-medium text-gray-700 hover:text-primary-600"
                  >
                    Sign in
                  </Link>
                  <Link
                    to="/register"
                    className="inline-flex items-center px-4 py-2 border border-transparent text-sm font-medium rounded-md text-white bg-primary-500 hover:bg-primary-600"
                  >
                    Sign up
                  </Link>
                </>
              )}
            </div>
          </div>
        </div>
      </nav>

      <main className="flex-grow max-w-7xl mx-auto py-6 px-4 sm:px-6 lg:px-8">
        {children}
      </main>

      <footer className="bg-white border-t border-gray-200">
        <div className="max-w-7xl mx-auto py-6 px-4 sm:px-6 lg:px-8">
          <div className="flex flex-col items-center justify-center space-y-4">
            <div className="text-sm text-gray-500">
              © 2024 PlayCafe. All rights reserved.
            </div>
            <div className="flex space-x-6">
              <a href="#" className="text-gray-400 hover:text-gray-500">
                Privacy Policy
              </a>
              <a href="#" className="text-gray-400 hover:text-gray-500">
                Terms of Service
              </a>
              <a href="#" className="text-gray-400 hover:text-gray-500">
                Contact Us
              </a>
            </div>
          </div>
        </div>
      </footer>
    </div>
  );
};

export default CustomerLayout; 