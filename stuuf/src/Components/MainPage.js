import React, { useState, useContext, useEffect } from 'react';
import axios from "axios";
import KonyvCard from "./KonyvCard";

const MainPage = (param) => {


    const [Konyvek, setKonyvek] = useState([]);

    const fetchData = async () => {
        const url = "https://localhost:5001/Konyv"
        const res = await axios.get(url);
        setKonyvek(res.data);
    }

    React.useEffect(()=>
    {
        fetchData();
    },[Konyvek])

    return(
        <div className="row">
            {
                Konyvek.map((item) => {
                    return <KonyvCard nev={item.nev} key={item.id} id={item.id}  kiadasEve={item.kiadasEve} ertekeles={item.ertekeles} kepneve={item.kepneve} />

                })
            }
        </div>
    )    
    
}

export default MainPage