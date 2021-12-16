import '../../assets/css/Home.css'
import '../../assets/css/Footer.css'
import Header from '../../Components/Header';



import { Component } from "react";

export default class Home extends Component {


    render() {
        return (
            <div>
                <Header Login="Login" Props={this.props} />

                <main>
                    <section class="container_participar">

                        <div class="cor_">
                            <div class="retangulo">

                            </div>

                        </div>



                    </section>
                </main>

                <footer/>
            </div>
        )
    };
}