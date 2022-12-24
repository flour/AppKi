import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';
import { readFileSync } from 'fs';
import { certFilePath, keyFilePath } from './aspnetcore-https';

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  resolve: {
    alias: {
      '@services': '/src/services',
      '@pages': '/src/pages',
      '@layout': '/src/layout',
      '@components': '/src/components',
      '@helpers': '/src/helpers'
    }
  },

  server: {
    https: {
      key: readFileSync(keyFilePath),
      cert: readFileSync(certFilePath)
    },
    port: 5002,
    strictPort: true,
    proxy: {
      '/api': {
        target: 'https://localhost:5001/',
        changeOrigin: true,
        secure: true
      }
    }
  }
});
