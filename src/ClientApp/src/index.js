import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';

import reportWebVitals from './reportWebVitals';
import {
  createBrowserRouter,
  RouterProvider,
  Route,
} from "react-router-dom";

import SingInPage from './pages/sing-in';
import LogInPage from './pages/log-in';
import Boards from './pages/boards';
import Board from './pages/board';

import 'bootstrap/dist/css/bootstrap.min.css';
import "react-datepicker/dist/react-datepicker.css";
import Accounts from './pages/accounts';


const root = ReactDOM.createRoot(document.getElementById('root'));
const router = createBrowserRouter([
  {
    path: "/sign-in",
    element: <SingInPage/>,
  },
  {
    path: "/login",
    element: <LogInPage/>,
  },
  {
    path: "/",
    element: <Boards/>,
  },
  {
    path: "/board/:boardID",
    element: <Board/>,
  },
  {
    path: "/accounts",
    element: <Accounts/>,
  },
]);
root.render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
