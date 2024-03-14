import { Link } from "react-router-dom"


const Navbar = () => {


    return (
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <div className="container-fluid">
                <Link to={"/"}>
                    <span className="navbar-brand">Könyvek</span>
                </Link>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>

                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                        <Link to={"/uj-konyv/"}>
                            <li className="nav-item">
                            <span className="nav-link active" aria-current="page" href="#">Könyv hozzáadása</span>
                            </li>
                        </Link>
                    </ul>
                </div>
            </div>
        </nav>
    )

}

export default Navbar