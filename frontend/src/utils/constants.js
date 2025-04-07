export const DEFAULT_IMAGES = {
  product: 'https://images.unsplash.com/photo-1495474472287-4d71bcdd2085',
  coffee: 'https://images.unsplash.com/photo-1509042239860-f550ce710b93',
  snack: 'https://images.unsplash.com/photo-1621939514649-280e2ee25f60',
  drink: 'https://images.unsplash.com/photo-1544145945-f90425340c7e'
};

export const getDefaultProductImage = (product) => {
  if (product?.imageUrl) return product.imageUrl;
  
  const categoryName = product?.subCategory?.category?.name?.toLowerCase();
  
  switch (categoryName) {
    case 'coffee':
      return DEFAULT_IMAGES.coffee;
    case 'snacks':
      return DEFAULT_IMAGES.snack;
    case 'drinks':
      return DEFAULT_IMAGES.drink;
    default:
      return DEFAULT_IMAGES.product;
  }
}; 