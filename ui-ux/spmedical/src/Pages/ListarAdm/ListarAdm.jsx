// import '../../assets/css/home.css'
// import '../../assets/css/footer.css'
// import '../../assets/css/consultas-listar.css'
// import Header from '../../components/header/header';
// import React, { useState, useEffect } from 'react';
// import { Link } from 'react-router-dom';
// import api from '../../services/api';


// export default function ListarAdm() {

//     const [listaConsultasAdm, setListaConsultasAdm] = useState([]);
//     // const [ isLoading, setIsLoading ] = useState( false );

//     function buscarConsultasAdm() {
//         console.log('vamos fazer a chamada para a API');

//         api.get('/Consulta/listarTodos', {
//             headers: {
//                 'Authorization': 'Bearer ' + localStorage.getItem('usuario-token')
//             }
//         })
//             .then(resposta => {
//                 if (resposta.status === 200) {
//                     setListaConsultasAdm(resposta.data)
//                 }
//             })

//             // caso ocorra algum erro, exibe no console do navegador este erro
//             .catch(erro => console.log(erro));
//     };

//     // estrutura do Hook useEffect
//     // useEffect( efeito, causa )
//     // useEffect( { o que vai ser feito }, { o que será escutado } )
//     // dessa forma, 
//     useEffect(buscarConsultasAdm, []);
// }