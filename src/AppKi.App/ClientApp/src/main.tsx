import React from 'react';
import {createRoot} from 'react-dom/client';
import {BrowserRouter} from 'react-router-dom';
import {ConfigProvider} from 'antd';
import App from './pages/App';
import AppWrapper from "@pages/AppWrapper";

import theme from './theme';
import './index.scss';

const container = document.getElementById('root');
const root = createRoot(container!);

root.render(
  <React.StrictMode>
    <BrowserRouter>
      <ConfigProvider theme={theme}>
        <AppWrapper><App/></AppWrapper>
      </ConfigProvider>
    </BrowserRouter>
  </React.StrictMode>
);
