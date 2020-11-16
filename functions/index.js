//const functions = require('firebase-functions');

//Create and Deploy Your First Cloud Functions
 //https://firebase.google.com/docs/functions/write-firebase-functions

//exports.helloWorld = functions.https.onRequest((request, response) => {
  //functions.logger.info("Hello logs!", {structuredData: true});
 /// response.send("Hello from Firebase!");
// });

var firebase = require("firebase");

const firebaseConfig = {
  apiKey: "AIzaSyDhh4ud5gY9vKBNga0-rdU4K_g5xxbPEBs",
  authDomain: "stockinator-b6fc4.firebaseapp.com",
  databaseURL: "https://stockinator-b6fc4.firebaseio.com",
  projectId: "stockinator-b6fc4",
  storageBucket: "stockinator-b6fc4.appspot.com",
  messagingSenderId: "771631229962",
  appId: "1:771631229962:web:07e6687fde352b263483f3",
  measurementId: "G-FH5C13MCV2"
};

firebase.initializeApp(firebaseConfig);
firebase.addUser();

//add user
function addUser(){
const database = firebase.database();
const createUser = user => database.ref().child(`User/${user.uid}`).set(user);
exports.createUser = functions.auth.user().onCreate(createUser);
}

//delete user
//connect user
//update password
//stock info per user
