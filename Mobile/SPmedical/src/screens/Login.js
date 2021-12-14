import React, { Component } from 'react';
import {
    StyleSheet,
    Text,
    TouchableOpacity,
    View,
    Image,
    TextInput,
} from 'react-native';

import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api';

export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: 'Kethelin@gmail.com',
            senha: 'Kethelin123',
        };
    }

    realizarLogin = async () => {

        console.warn(this.state.email + ' ' + this.state.senha);

        const resposta = await api.post('/login', {
            email: this.state.email,
            senha: this.state.senha,
        });

        const token = resposta.data.token;
        await AsyncStorage.setItem('userToken', token);

        if (resposta.status == 200) {
            console.warn("ASD")
            this.props.navigation.navigate('Main');
        }

        console.warn(token);

        
    };

    render() {
        return (
            <View
                style={StyleSheet.absoluteFillObject}>
                {/* retangulo azul */}
                <View style={styles.overlay}>
                    <View style={styles.main}>
                        <Image
                            source={require('../../Assets/img/Logo.png')}
                            style={styles.mainImgLogin}
                        />

                        <View style={styles.boxLogin}>
                            <TextInput
                                style={styles.inputLogin}
                                placeholder="Email"
                                placeholderTextColor="#FFF"
                                keyboardType="email-address"
                                // ENVENTO PARA FAZERMOS ALGO ENQUANTO O TEXTO MUDA
                                onChangeText={email => this.setState({ email })}
                            />

                            <TextInput
                                style={styles.inputLogin}
                                placeholder="Senha"
                                placeholderTextColor="#FFF"
                                keyboardType="default" //para default nao obrigatorio.
                                secureTextEntry={true} //proteje a senha.
                                // ENVENTO PARA FAZERMOS ALGO ENQUANTO O TEXTO MUDA
                                onChangeText={senha => this.setState({ senha })}
                            />

                            <TouchableOpacity
                                style={styles.btnLogin}
                                onPress={this.realizarLogin}>
                                <Text style={styles.btnLoginText}>Entrar</Text>
                            </TouchableOpacity>
                        </View>
                    </View>
                </View>
            </View>
        );
    }
}

const styles = StyleSheet.create({
    //antes da main
    overlay: {
        ...StyleSheet.absoluteFillObject, //todas as prop do styleShhet, e vamos aplica o abosluteFIL...
        backgroundColor: 'rgba(109, 175, 236, 0.75)', //rgba pq vamos trabalhar com transparencia.
    },

    // conteúdo da main
    main: {
        // flex: 1,
        backgroundColor: '#13599A',
        justifyContent: 'center',
        alignItems: 'center',
        width: '100%',
        height: '100%',
    },



    boxLogin:{
        borderRadius: 25,
        backgroundColor: 'transparent',
        padding:50,
        alignItems: 'center',
        justifyContent: 'center',
    },

    inputLogin: {
        width: 240, //largura mesma do botao
        marginBottom: 40, //espacamento pra baixo
        fontSize: 18,
        color: '#FFF',
        borderColor: '#FFF', //linha separadora
        borderWidth: 4, //espessura.
        borderRadius: 25,
        backgroundColor: 'transparent'
    },

    btnLoginText: {
        fontSize: 18, //aumentar um pouco
        fontFamily: 'Open Sans Light', //troca de fonte
        color: '#fff', //mesma cor identidade
        // letterSpacing: 6, //espacamento entre as letras
        textTransform: 'uppercase', //estilo maiusculo
    },
    btnLogin: {
        alignItems: 'center',
        justifyContent: 'center',
        height: 38,
        width: 93,
        // borderWidth: 1,
        shadowOffset: { height: 1, width: 1 },
        borderColor: '#055BC0', //linha separadora
        borderWidth: 2, //espessura.
        borderRadius: 25,
        backgroundColor: '#055BC0'
    },
});