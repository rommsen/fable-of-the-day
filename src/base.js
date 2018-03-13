import Rebase from "re-base";
import firebase from "firebase";

const firebaseApp = firebase.initializeApp({
  apiKey: "AIzaSyBFiYmjUURidV7w6674QfIiHfWMixH88aE",
  authDomain: "catch-of-the-day-rommsen.firebaseapp.com",
  databaseURL: "https://catch-of-the-day-rommsen.firebaseio.com",

});

const base = Rebase.createClass(firebaseApp.database());

// This is a named export
export { firebaseApp };

// this is a default export
export default base;
