import { Col, Layout, Menu, Row, theme } from 'antd';
import React from 'react';

const { Header, Content, Footer, Sider } = Layout;


const App: React.FC = () => {
  const {
    token: { colorBgContainer }
  } = theme.useToken();

  const layoutsStyle: React.CSSProperties = {
    padding: 12,
    margin: 12,
    borderRadius: 5,
    background: colorBgContainer
  };

  return (
    <Layout className='layout'>
      <Header>
        <div className='logo' />
        <Menu
          theme='dark'
          mode='horizontal'
          defaultSelectedKeys={['2']}
          items={new Array(5).fill(null).map((_, index) => {
            const key = index + 1;
            return {
              key,
              label: `nav ${key}`
            };
          })}
        />
      </Header>
      <Layout>
        <Sider width={230} style={layoutsStyle}>
          menu
        </Sider>
        <Content style={{ ...layoutsStyle, ...{ minHeight: 280 } }}>
          Content
        </Content>
      </Layout>

      <Footer style={{ textAlign: 'center' }}>AppKi ©2023 Created by ...</Footer>
    </Layout>
  );
};

export default App;
