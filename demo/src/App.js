import logo from './logo.svg';
import './App.css';
import Header from './Header';
import Content from './Content';
import Footer from './Footer';
import Hello from './Hello';
import Greet from './Greet';
import Message from './Message';

function App() {
  // function handleNameChange(){
  //   const names=["Earn","Give","Grow"];
  //   const int=Math.floor(Math.random()*3);
  //   return names[int];
  // }
  return (
    <div className='App'>
      {/* <p>Lets{handleNameChange()}Money</p> */}
      {/* <Header/>
      <Footer/>
      <Content/> */}
      <Hello/>
      <Greet name="Navee"/>
      <button>Hoiiiii</button>
      <Greet name="Pangu"/>
      <Message/>
    </div>
  );
}

export default App;
