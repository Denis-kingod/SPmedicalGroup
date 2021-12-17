import '../../assets/css/Header.css'
import '../../assets/css/Home.css'
import '../../assets/css/Footer.css'
import Footer from '../../Components/Footer'
import Header from '../../Components/Header';



import { Component } from "react";

export default class Home extends Component {


    render() {
        return (
            <div>
                <Header/>

                <main>
                    <section class="container_participar">

                        <div class="cor_">
                            <div class="retangulo">

                            </div>

                        </div>



                    </section>
                </main>

                <Footer/>
            </div>
        )
    };
}