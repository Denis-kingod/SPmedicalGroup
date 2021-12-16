

import Header from '../../Components/Header'
import Footer from '../../Components/Footer'


import { useState, useEffect } from "react";
import api from '../../services/api';


export default function Cadastrar() {
    const [listaPacientes, setListaPacientes] = useState([]);
    const [listaMedicos, setListaMedicos] = useState([]);


    const [idPaciente, setIdPaciente] = useState(0);
    const [idMedico, setIdMedico] = useState(0);
    const [idSituacao, setIdSituacaoPaciente] = useState(0);
    const [dataConsulta, setDataConsulta] = useState(new Date());
    const [descricaoConsulta, setDescricaoConsulta] = useState("");



    function buscarPacientes() {
        api.get('/Paciente/tudo', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-token')
            }
        }).then(resposta => {
            if (resposta.status === 200) {
                setListaPacientes(resposta.data);
                console.log(resposta.data)
            }
        }).catch((erro) => console.log(erro))
    }

    useEffect(buscarPacientes, []);

    function buscarMedico() {
        api.get('/Medico', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-token')
            }
        }).then(resposta => {
            if (resposta.status === 200) {
                setListaMedicos(resposta.data);
                console.log(resposta.data)
            }
        }).catch((erro) => console.log(erro))
    }

    useEffect(buscarMedico, [])

    // atualizaStateCampo = (campo) => {
    //     this.setState({ [campo.target.name]: campo.target.value });
    // };

    function cadastrarConsulta(evento) {
        evento.preventDefault();
        api.post('/Consulta', {
            idMedico: idMedico,
            idPaciente: idPaciente,
            idSituacao: idSituacao,
            dataConsulta: dataConsulta,
            descricao: descricaoConsulta
        }, {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-token'),
            },
        })
            .then(resposta => {
                if (resposta.status === 201) {
                    console.log('Consulta Cadastrada')
                    setIdPaciente(0);
                    setIdMedico(0);
                    setIdSituacaoPaciente(0);
                    setDataConsulta(new Date());
                    setDescricaoConsulta("");
                    window.location.href = "/listarAdm"

                }
            })
            .catch((erro) => {
                if (erro.toJSON().status === 401) {
                    window.location.href = "/login"
                }
                else console.log(erro)
            })
    }
}