import logo from './logo.svg'
import styles from './App.module.scss'
import { RandomBanner } from './components/RandomBanner';
function App() {


  return (
    <div className="App">
      <div className={styles.toolbar}><h3>Palvkering</h3><p><RandomBanner /></p></div>
      <div className={styles.container}>
        <div className={styles.content}>
          <h4>Legg til kode her</h4>
        </div>
        <ul className={styles.tasks}>
          <li>TODO: Vi vil bare ha parkeringene i nærheten av oss. Kan vi gjøre det slik at API'et tar inn longitude og latitude og gir oss parkeringer innenfor en 5km radius?</li>
          <li>TODO: Gjør det mulig å bare hente gratis parkeringer</li>
          <li>TODO: Gjør det mulig å bare hente parkeringer med lademuligheter</li>
          <li>TODO: Implementer paginering. Nå får man bare de første N antall parkeringer. Gjør det mulig å hente flere</li>
        </ul>
      </div>
    </div>
  );
}


export default App
