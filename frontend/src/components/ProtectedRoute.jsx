import { Navigate, useLocation } from 'react-router-dom';
import { isAuthenticated, isAdmin } from '../services/auth';

export const ProtectedRoute = ({ children, requireAdmin = false }) => {
  const location = useLocation();

  if (!isAuthenticated()) {
    return <Navigate to="/login" state={{ from: location }} replace />;
  }

  if (requireAdmin && !isAdmin()) {
    return <Navigate to="/" replace />;
  }

  return children;
}; 