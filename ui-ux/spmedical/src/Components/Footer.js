import React from 'react'

import whats from '../assets/img/whats.png'
import Face from '../assets/img/Face.png'
import Insta from '../assets/img/Insta.png'
// Insta.png
// Face.png
// whats.png


export default function Footer() {

    return (

        <footer>
            <div class="container_footer container">
                <div class="container_footer ">
                    <a href="">Clinica SPmedGroup</a>

                    <div class="span1">
                        <span>Informaçoes:</span>
                    </div>
                    <div class="img_footer">
                        <a href=""><img src={whats} alt="" /></a>
                        <a href=""><img src={Face} alt="" /></a>
                        <a href=""><img src={Insta} alt="" /></a>
                    </div>
                    <p>CNPJ:12345678</p>
                </div>
            </div>
        </footer >
    )
}