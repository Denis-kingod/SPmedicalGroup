// import '../../assets/css/home.css'
// import '../../assets/css/footer.css'
// import '../../assets/css/consultas-listar.css'
// import Header from '../../components/header/header';
// import marker from '../../assets/img/mapmarker.png';


// import React, { useState, useEffect } from 'react';
// import { Link } from 'react-router-dom';
// import api from '../../services/api';


// export default function ListarPaciente() {
//     var [erroMensagem = ''] = useState([])

//     const [listaConsultasPaciente, setListaConsultasPaciente] = useState([]);
//     // const [ isLoading, setIsLoading ] = useState( false );

//     function buscarConsultasPaciente() {


//         api.get('/Consulta/minhas', {
//             headers: {
//                 'Authorization': 'Bearer ' + localStorage.getItem('usuario-token')
//             }
//         })
//             .then(resposta => {
//                 if (resposta.status === 200) {
//                     setListaConsultasPaciente(resposta.data)
//                 }
//             })

//             // caso ocorra algum erro, exibe no console do navegador este erro
//             .catch(erro => console.log(erro));
//     };

//     function listarConsulta() {
//         if (listaConsultasPaciente.length === 0) {
//            erroMensagem = 'Você não possui nenhuma consulta cadastrada'
            
            
//         } else  {
            
         
//             return(
//                 listaConsultasPaciente.map((Consulta) => {
//                     return (
//                         <div className="box_consulta" key={Consulta.idConsulta}>
//                             <h2 className="h2_consulta">Consulta {Consulta.idConsulta}</h2>
//                             <div className="box_info">
//                                 <h3>Data</h3>
//                                 <p>{Intl.DateTimeFormat("pt-BR", {
//                                     year: 'numeric', month: 'short', day: 'numeric',
//                                     hour: 'numeric', minute: 'numeric',
//                                     hour12: true
//                                 }).format(new Date(Consulta.dataConsulta))}</p>
//                                 <h3>Descrição</h3>
//                                 <p>{Consulta.descricao}</p>
//                                 <h3>Situação</h3>
//                                 <p>{Consulta.idSituacaoNavigation.situacao1}</p>
//                             </div>
//                             <h2 className="h2_consulta">Médico</h2>
//                             <div className="box_info">
//                                 <h3>Nome</h3>
//                                 <p>{Consulta.idMedicoNavigation.nomeMed}</p>
//                                 <h3>CRM</h3>
//                                 <p>{Consulta.idMedicoNavigation.crm}</p>
//                                 <h3>Especialidade</h3>
//                                 <p>{Consulta.idMedicoNavigation.idEspecialidadeNavigation.tituloEspecialidade}</p>
//                                 <h3>Clínica</h3>
//                                 <p>{Consulta.idMedicoNavigation.idClinicaNavigation.nomeFantasia}</p>
//                                 <h3>Endereço Clínica</h3>
//                                 <p>{Consulta.idMedicoNavigation.idClinicaNavigation.idEnderecoNavigation.rua}, {Consulta.idMedicoNavigation.idClinicaNavigation.idEnderecoNavigation.numero}<Link className="img-map" to="/mapa"><img alt="Imagem marcador" src={marker}/></Link></p>
//                             </div>
//                         </div>
//                     )
//                 })
//             )
            

//         }

//     }

//     // estrutura do Hook useEffect
//     // useEffect( efeito, causa )
//     // useEffect( { o que vai ser feito }, { o que será escutado } )
//     // dessa forma, 
//     useEffect(buscarConsultasPaciente, []);
// }