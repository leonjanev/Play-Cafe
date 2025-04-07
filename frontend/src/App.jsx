import { BrowserRouter, Routes, Route, Navigate, Outlet } from 'react-router-dom';
import { ProtectedRoute } from './components/ProtectedRoute';
import CustomerLayout from './components/layouts/CustomerLayout';
import AdminLayout from './components/layouts/AdminLayout';
import Login from './pages/auth/login';
import Register from './pages/auth/register';
import Home from './pages/customer/Home';
import ProductList from './pages/customer/ProductList';
// Admin imports
import Products from './pages/admin/products';
import CreateProduct from './pages/admin/products/create';
import EditProduct from './pages/admin/products/edit';
import Categories from './pages/admin/categories';
import CreateCategory from './pages/admin/categories/create';
import EditCategory from './pages/admin/categories/edit';
import Subcategories from './pages/admin/subcategories';
import CreateSubcategory from './pages/admin/subcategories/create';
import EditSubcategory from './pages/admin/subcategories/edit';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        {/* Public routes */}
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
        
        {/* Customer routes */}
        <Route path="/" element={<CustomerLayout><Outlet /></CustomerLayout>}>
          <Route index element={<Home />} />
          <Route path="category/:categoryId" element={<ProductList />} />
          <Route path="subcategory/:subcategoryId" element={<ProductList />} />
        </Route>

        {/* Admin routes */}
        <Route
          path="/admin"
          element={
            <ProtectedRoute requireAdmin>
              <AdminLayout><Outlet /></AdminLayout>
            </ProtectedRoute>
          }
        >
          <Route index element={<Home />} />
          <Route path="products" element={<Products />} />
          <Route path="products/create" element={<CreateProduct />} />
          <Route path="products/edit/:id" element={<EditProduct />} />
          <Route path="categories" element={<Categories />} />
          <Route path="categories/create" element={<CreateCategory />} />
          <Route path="categories/edit/:id" element={<EditCategory />} />
          <Route path="subcategories" element={<Subcategories />} />
          <Route path="subcategories/create" element={<CreateSubcategory />} />
          <Route path="subcategories/edit/:id" element={<EditSubcategory />} />
        </Route>

        {/* Catch all */}
        <Route path="*" element={<Navigate to="/" replace />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
