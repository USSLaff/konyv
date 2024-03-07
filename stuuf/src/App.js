import logo from './logo.svg';
import './App.css';
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Navbar from './Components/Navbar';
import MainPage from './Components/MainPage';
import { KonyvPost } from './Components/NewKonyvPage';
import React from 'react';
import KonyvSingle from './Components/KonyvSingle';
import { KonyvPut } from './Components/UpdKonyvPage';

function App() {

  const [konyvek, setKonyvek] = React.useState([]);
  const [isFetchPending, setFetchPending] = React.useState(true)
  const [selectedKonyv, setSelectedKonyv] = React.useState({});

  return (
    <div>
      <Router>
        <Navbar />

        <div className='container mt-5'>

          <Routes>
            <Route path="/" element={<MainPage setFetchPending={setFetchPending} isFetchPending={isFetchPending}/>} />
            <Route path="/uj-konyv/" element={<KonyvPost setFetchPending={setFetchPending} isFetchPending={isFetchPending}/>} />
            <Route path="/upd-konyv/:id" element={<KonyvPut setFetchPending={setFetchPending} isFetchPending={isFetchPending}/>} />
            <Route path="/konyv/:id" element={<KonyvSingle setFetchPending={setFetchPending} isFetchPending={isFetchPending}/>} />


          </Routes>
        </div>
      </Router>
    </div>
  );
}

export default App;
