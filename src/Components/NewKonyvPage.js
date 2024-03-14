import React from 'react'
import axios from 'axios';
import { Link, useNavigate } from 'react-router-dom'

export const KonyvPost = ({ setFetchPending }) => {
    const navigate = useNavigate();
    return (
        <div className='container w-25 mt-5 border border-2 p-2 rounded-3'>
            <form onSubmit={async (e) => {
                e.preventDefault();
                e.persist();

                const konyvNev = e.target.konyvNev.value
                const konyvKiadas = e.target.konyvKiadas.value
                const konyvErtekeles = e.target.konyvErtekeles.value
                const konyvBorito = e.target.konyvBorito.value
                

                const postData = {
                    id: 0,
                    nev: konyvNev,
                    kiadasEve: konyvKiadas,
                    ertekeles: konyvErtekeles,
                    kepneve : konyvBorito

                }
                await axios.post('https://localhost:5001/Konyv/', postData).then(async () => {
                    await setFetchPending(true);
                    navigate('/');
                });

            }}>
                <div className="mb-3">
                    <label htmlFor="konyvNev" className="form-label">Könyv neve</label>
                    <input type="text" className="form-control" id="konyvNev" />
                </div>
            
                <div className="mb-3">
                    <label htmlFor="konyvKiadas" className="form-label">Könyv Kiadásának Éve</label>
                    <input type="text" className="form-control" id="konyvKiadas" />
                </div>

                <div className="mb-3">
                    <label htmlFor="konyvErtekeles" className="form-label">Könyv Értékelése</label>
                    <input type="text" className="form-control" id="konyvErtekeles" />
                </div>

                <div className="mb-3">
                    <label htmlFor="konyvBorito" className="form-label">Könyv borító címe</label>
                    <input type="text" className="form-control" id="konyvBorito" />
                </div>

                <button type="submit" className="btn btn-success me-2">Mentés</button>
                <Link type="button" className="btn btn-warning" to="/">Vissza</Link>

            </form>
        </div>
    )
}
