/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        primary: {
          50: '#fdf2f4',
          100: '#fce7ea',
          200: '#f9d2d8',
          300: '#f4adb8',
          400: '#ec7d8f',
          500: '#B31942', // Your logo's primary color
          600: '#a11539',
          700: '#8c1231',
          800: '#78112c',
          900: '#681329',
          950: '#3a0816',
        },
        secondary: {
          500: '#808080', // The grey color from your logo
        }
      }
    },
  },
  plugins: [],
}

