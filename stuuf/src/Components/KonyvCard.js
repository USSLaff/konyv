import axios, { Axios } from "axios"
import { useContext } from "react"
import { Link } from "react-router-dom"



const KonyvCard = (params) => {

    return (
        <div className="col-4 mb-2">
            <div className="card text-center">
                <div className="card-header ">
                    Könyv neve: {params.nev}
                    <h4>Kiadás éve: {params.kiadasEve}</h4>
                    <h5>értékelés: {params.ertekeles}</h5>
                </div>
                <div className="card-body">
                    <Link to={`/konyv/${params.id}`}>
                        <img src={params.kepneve} className="card-img-top w-75" alt="..." />
                    </Link>
                </div>
                <div className="card-footer">
                    <Link to={`/upd-konyv/${params.id}`} className="btn-primary me-5 btn btn-warning w-25"><i className="bi bi-pencil"></i></Link>
                    <button to={`/konyv/${params.id}`} className="btn-primary ms-5 btn btn-danger w-25" onClick={async () => {
                        try{
                        axios.delete(`https://localhost:5001/Konyv/${params.id}`)
                        }catch(err){
                            console.log(err);
                        }

                    }} ><i className="bi bi-trash3"></i></button>
                </div>
            </div>

        </div>
    )
}

export default KonyvCard