import vector from '../assets/img/image2vector.png'

export default function Header(){

    return (
        <header>

            <div class="Container_footer container">

                <div class="container container_header">
                    <img class="Header_logo" src={vector} alt="Logo" />
                    <nav class="menu_header">
                        <div class="container_header_a">
                            <a href="">Sobre nós</a>
                            <a href="">Agendamento</a>
                            <a href="">Consulta</a>
                            <a href="">Login</a>
                            <a href="">Cadastro</a>
                        </div>
                    </nav>

                </div>
            </div>
        </header>

    )
}