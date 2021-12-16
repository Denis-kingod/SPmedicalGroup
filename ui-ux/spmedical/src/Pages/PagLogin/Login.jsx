// import '../../assets/css/login.css'
// import '../../assets/css/header.css'
// import Header from '../../components/header/header';
// import { parseJwt } from '../../services/auth';


// import { Component } from "react";
// // import axios from 'axios';
// import api from '../../services/api';

// export default class Login extends Component {
//     constructor(props) {
//         super(props)
//         this.state = {
//             // email: 'denis@gmail.com',
//             // senha: 'denis123',
//             // email: 'sherlok.holmes@spmedicalgroup.com.br',
//             // senha: '12345',
//             email: 'Kethelin@gmail.com',
//             senha: 'Kethelin123',
//             erroMensagem: '',
//             isLoading: false
//         };
//     };

//     efetuaLogin = (event) => {
//         this.setState({ erroMensagem: " ", isLoading: true })
//         event.preventDefault();
//         api.post('/login', {
//             email: this.state.email,
//             senha: this.state.senha
//         })

//             .then(resposta => {
//                 if (resposta.status === 200) {
//                     console.log(resposta.data.token)
//                     localStorage.setItem('usuario-token', resposta.data.token)
//                     this.setState({ isLoading: false });
                    
                   
                    
//                     switch (parseJwt().role) {
//                         case '3':
//                             // verifica se o usuário logado é do tipo paciente
//                             this.props.history.push('/listarPaciente');                          
//                             break;
//                             case '1':
//                             // verifica se o usuário logado é do tipo administrador
//                             this.props.history.push('/listarAdm');
//                             break;
//                             case '2':
//                             // verifica se o usuário logado é do tipo médico
//                             this.props.history.push('/listarMedico');
//                             break;
//                         default:
//                             this.props.history.push('/');
//                             break;
//                     }
//                 }
//             })

//             .catch(() => {
//                 this.setState({ isLoading: false });
//                 this.setState({ erroMensagem: "E-mail ou senha inválidos!" })
//             })
//     }

//     atualizaStateCampo = (campo) => {
//         this.setState({ [campo.target.name]: campo.target.value })
//     }
// }
