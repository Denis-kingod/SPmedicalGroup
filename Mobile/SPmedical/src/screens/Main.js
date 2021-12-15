import React, { Component } from 'react';
import {
    Image,
    StatusBar,
    StyleSheet,
    View,
} from 'react-native';

import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';

const bottomTab = createBottomTabNavigator();


import Perfil from '../screens/Perfil';
import Listar from './Listar';




export default class Main extends Component {

    render() {
        return (

            <View style={styles.main}>
                <StatusBar
                    hidden={false}
                />

                <bottomTab.Navigator
                    initialRouteName = 'Listar'


                    // versão 5.x do React Navigation
                    // tabBarOptions={{
                    //   showLabel: false,
                    //   showIcon: true,
                    //   activeBackgroundColor: '#B727FF',
                    //   inactiveBackgroundColor: '#DD99FF',
                    //   activeTintColor: 'red',
                    //   inactiveTintColor: 'blue',
                    //   style: { height: 50 }
                    // }}

                    screenOptions={({ route }) => ({
                        tabBarIcon: () => {
                                // if (route.name === 'Home') {
                                //     return (
                                //         <Image
                                //             source={require('../../assets/img/Logo.png')}
                                //             style={styles.tabBarIcon}
                                //         />
                                //     )
                                // }
                            if (route.name === 'Listar') {
                                return (
                                    <Image
                                        source={require('../../Assets/img/prancheta.png')}
                                        style={styles.tabBarIcon}
                                    />
                                )
                            }

                            
                            if (route.name === 'Perfil') {
                                return (
                                    <Image
                                        source={require('../../Assets/img/profile.png')}
                                        style={styles.tabBarIcon}
                                    />
                                )
                            }
                        },

                        // React Navigation 6.x
                        headerShown: false,
                        tabBarShowLabel: false,
                        tabBarActiveBackgroundColor: '#6DAFEC',
                        tabBarInactiveBackgroundColor: '#055BC0',
                        // tabBarActiveTintColor: 'blue',
                        // tabBarInactiveTintColor: 'red',
                        tabBarStyle: { height: 50 }
                    })}>

                    <bottomTab.Screen name="Listar" component={Listar} />
                    <bottomTab.Screen name="Perfil" component={Perfil} />

                </bottomTab.Navigator>

            </View>
        );
    }

};

const styles = StyleSheet.create({

    // conteúdo da main
    main: {
        flex: 1,
        backgroundColor: '#F1F1F1'
    },

    // estilo dos ícones da tabBar
    tabBarIcon: {
        width: 22,
        height: 22
    }

});