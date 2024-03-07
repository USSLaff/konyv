import React from 'react'
import axios from 'axios'
import { Link, useNavigate, useParams } from 'react-router-dom'
import { useEffect } from 'react'

export const KonyvPut = ({ setFetchPending }) => {
    const navigate = useNavigate();
    const param = useParams();

    const [formPendingFetch, setFormPendingFetch] = React.useState(true)

    const [id,setID ] = React.useState("");
    const [nev, setNev] = React.useState("")
    const [ertekeles, setErtekeles] = React.useState("")
    const [kepneve, setKepcim] = React.useState("")
    const [kiadas, setKiadas] = React.useState("")


    const fetchData = async () => {
        await axios.get(`https://localhost:5001/Konyv/${param.id}`).then(async (response) => {

            console.log(response.data)

            setID(response.data.id)
            setNev(response.data.nev);
            setErtekeles(response.data.ertekeles);
            setKepcim(response.data.kepneve);
            setKiadas(response.data.kiadasEve);

        }).finally(() => setFormPendingFetch(false));
    }

    useEffect(() => {
        fetchData();
    }, [formPendingFetch]);

    const Nev = (e) => {
        setNev(e.target.value)
    }

    const Ertekeles = (e) => {
        setErtekeles(e.target.value)
    }

    const Kepcim = (e) => {
        setKepcim(e.target.value)
    }

    const Kiadas = (e) => {
        setKiadas(e.target.value)
    }

    return (
        <div className='container w-25 mt-5 border border-2 p-2 rounded-3'>
            <form onSubmit={async (e) => {
                e.preventDefault();
                e.persist();

                const konyvNev = e.target.konyvNev.value
                const konyvKiadas = e.target.konyvKiadas.value
                const konyvErtekeles = e.target.konyvErtekeles.value
                const konyvBorito = e.target.konyvBorito.value


                const putData = {
                    id: id,
                    nev: konyvNev,
                    kiadasEve: konyvKiadas,
                    ertekeles: konyvErtekeles,
                    kepneve: konyvBorito
                }

                await axios.put(`https://localhost:5001/Konyv/${param.id}`, putData).then(async () => {
                    await setFetchPending(true);
                    navigate('/');
                });

            }}>

                <div className="mb-3">
                    <label htmlFor="konyvNev" className="form-label">Könyv neve</label>
                    <input onChange={Nev} type="text" className="form-control" id="konyvNev" defaultValue={nev} />
                </div>

                <div className="mb-3">
                    <label htmlFor="konyvKiadas" className="form-label">Könyv Kiadásának Éve</label>
                    <input onChange={Kiadas} type="text" className="form-control" id="konyvKiadas" defaultValue={kiadas} />
                </div>

                <div className="mb-3">
                    <label htmlFor="konyvErtekeles" className="form-label">Könyv Értékelése</label>
                    <input onChange={Ertekeles} type="text" className="form-control" id="konyvErtekeles" defaultValue={ertekeles} />
                </div>

                <div className="mb-3">
                    <label htmlFor="konyvBorito" className="form-label">Könyv borító címe</label>
                    <input onChange={Kepcim} type="text" className="form-control" id="konyvBorito" defaultValue={kepneve} />
                </div>

                <button type="submit" className="btn btn-success me-2">Mentés</button>
                <Link type="button" className="btn btn-warning" to="/">Vissza</Link>

            </form>
        </div>
    )
}
