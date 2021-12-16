import React from 'react';
import ReactDOM from 'react-dom';
import {
  Route,
  BrowserRouter as Router,
  Redirect,
  Switch,
} from 'react-router-dom';
import { parseJwt, usuarioAutenticado } from './services/auth';

import './index.css';

import Home from './Pages/Home/Home';
import Login from './Pages/PagLogin/Login';
import Cadastrar from './Pages/Cadastrar/Cadastrar.jsx';
import ListarAdm from './Pages/ListarAdm/ListarAdm.jsx';
import ListarPaciente from './Pages/ListarPaciente/ListarPaciente.jsx';
import ListarMedico from './Pages/ListarMedico/ListarMedico.jsx';
import NotFound from './Pages/NotFound/NotFound';

import reportWebVitals from './reportWebVitals';

const PermissaoAdm = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJwt().role === '2' ? (
        // operador spread
        <Component {...props} />
      ) : (
        <Redirect to="login" />
      )
    }
  />
);
const PermissaoAdmC = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJwt().role === '2' ? (
        // operador spread
        <Component {...props} />
      ) : (
        <Redirect to="permissao" />
      )
    }
  />
);

const PermissaoPaciente = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJwt().role === '1' ? (
        // operador spread
        <Component {...props} />
      ) : (
        <Redirect to="login" />
      )
    }
  />
);

const PermissaoMedico = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJwt().role === '3' ? (
        // operador spread
        <Component {...props} />
      ) : (
        <Redirect to="login" />
      )
    }
  />
);


const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Home} /> {/* Home */}
        <Route path="/login" component={Login} /> {/* Login */}
        <Route path="/NotFound" component={NotFound} /> {/* Not Found */}
        <PermissaoAdm path="/listarAdm" component={ListarAdm} /> {/* Listar Adm */}
        <PermissaoAdmC path="/cadastrar" component={Cadastrar} /> {/* Cadastrar */}
        <PermissaoPaciente path="/listarPaciente" component={ListarPaciente} /> {/* Listar Paciente */}
        <PermissaoMedico path="/listarMedico" component={ListarMedico} /> {/* Listar Médico */}
      </Switch>
    </div>
  </Router>
);

ReactDOM.render(
  routing,
  document.getElementById('root')
);

reportWebVitals();
