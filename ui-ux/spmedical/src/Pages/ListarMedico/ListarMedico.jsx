// import '../../assets/css/home.css'
// import '../../assets/css/footer.css'
// import '../../assets/css/consultas-listar.css'
// import Lapis from '../../assets/img/lapis.png';
// import Header from '../../components/header/header';

// import { Link } from 'react-router-dom';
// import React, { useState, useEffect } from 'react';
// import api from '../../services/api';


// export default function ListarMedico() {

//     const [listaConsultasMedico, setListaConsultasMedico] = useState([]);
//     const [descricaoConsulta, setDescricao] = useState("");
//     // const [ isLoading, setIsLoading ] = useState( false );

//     function buscarConsultasMedico() {


//         api.get('/Consulta/minhas', {
//             headers: {
//                 'Authorization': 'Bearer ' + localStorage.getItem('usuario-token')
//             }
//         })
//             .then(resposta => {
//                 if (resposta.status === 200) {
//                     setListaConsultasMedico(resposta.data)
//                     console.log(resposta.data)
//                 }
//             })

//             // caso ocorra algum erro, exibe no console do navegador este erro
//             .catch(erro => console.log(erro));
//     };

//     // estrutura do Hook useEffect
//     // useEffect( efeito, causa )
//     // useEffect( { o que vai ser feito }, { o que será escutado } )
//     // dessa forma, 
//     useEffect(buscarConsultasMedico, []);

//     function atualizarDescricaoConsulta(idConsulta) {

//         api.patch("/Consulta/descricao/" + idConsulta, {
//             descricao: descricao
//         }, {
//             headers: {
//                 'Authorization': 'Bearer ' + localStorage.getItem('usuario-token')
//             }
//         })
//             .then(resposta => {
//                 if (resposta.status === 204) {
//                     console.log("descricao da consulta " + idConsulta + " atualizada");
//                     // document.getElementById(idConsulta).setAttribute("readOnly");
//                     var btn = document.getElementById("btn" + idConsulta)
//                     var p = document.getElementById("desc"+ idConsulta);
//                     var textarea = document.getElementById("descricao"+ idConsulta) 
//                     btn.style.display = "none";
//                     p.style.display = "";
//                     textarea.style.display = "none";
                    
//                     buscarConsultasMedico();
//                     setDescricaoConsulta("")
//                 }
//             }).catch(erro => console.log(erro))
//     }

//     function permitirTextArea(idConsulta, descricaoConsulta) {
//         // console.log("Você está editando a situação da consulta " + idConsulta + "e a situação é " + idSituacao)
//         setDescricaoConsulta(descricaoConsulta);
//         console.log(descricaoConsulta)
//         var textoDescricao = document.getElementById("descricao" + idConsulta)
//         // textoDescricao.removeAttribute("readOnly");
//         // descricao = descricaoConsulta
//         document.getElementById("descricao" + idConsulta).value = descricaoConsulta

//         if (textoDescricao.value === null || textoDescricao.value === "") {
//             textoDescricao.value = "Consulta sem descrição";

//         }
//         var btn = document.getElementById("btn" + idConsulta);
//         var p = document.getElementById("desc"+ idConsulta);
//         var textarea = document.getElementById("descricao"+ idConsulta);

//         if (btn.style.display === "none") {
//             btn.style.display = "";
//             p.style.display = "none";
//             textarea.style.display = "";
//             // textoDescricao.removeAttribute("readOnly");
//         } else {


//             p.style.display = "";
//             textarea.style.display = "none";

//             setDescricao("")
//             btn.style.display = "none";
//         }


//     }
// }