import React, { useState, useContext, useEffect } from 'react';
import axios from "axios";
import KonyvCard from "./KonyvCard";
import { useParams } from 'react-router-dom';

const KonyvSingle = (item) => {

    const param = useParams();

    const [Konyv, setKonyv] = useState([]);

    const fetchData = async () => {
        const url = `https://localhost:5001/Konyv/${param.id}`
        const res = await axios.get(url);
        setKonyv(res.data);
    }

    React.useEffect(() => {
        fetchData();
    }, [Konyv])

    return (
        <div className="row text-center">
            {

                <KonyvCard nev={Konyv.nev} key={Konyv.id} kiadasEve={Konyv.kiadasEve} id={Konyv.id} ertekeles={Konyv.ertekeles} kepneve={Konyv.kepneve} />


            }
        </div>
    )

}

export default KonyvSingle