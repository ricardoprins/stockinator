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

<<<<<<< Updated upstream
//delete user
//connect user
//update password
//stock info per user
=======

firebase.addUser();

firebase.deleteUser();

firebase.savedState();

firebase.logIn();

firebase.updateName();
firebase.updatePassword();

//add user
function addUser(){
  firebase.auth().createUserWithEmailAndPassword(email, password)
  .then((user) => {
    // Signed in 
    // ...
  })
  .catch((error) => {
    var errorCode = error.code;
    var errorMessage = error.message;
    // ..
  });
}

//delete user
function deleteUser(){
  var user = firebase.auth().currentUser;

  user.delete().then(function() {
    // User deleted.
  }).catch(function(error) {
    // An error happened.
  });
}

//connect user
function logIn(){
 
  firebase.auth().signInWithEmailAndPassword(email, password)
  .then((user) => {
    // Signed in 
    // ...
  })
  .catch((error) => {
    var errorCode = error.code;
    var errorMessage = error.message;
  });
}

//update name and photo
function updateName(){
  var user = firebase.auth().currentUser;

  user.updateProfile({
    displayName: "Jane Q. User",
    photoURL: "https://example.com/jane-q-user/profile.jpg"
  }).then(function() {
    // Update successful.
  }).catch(function(error) {
    // An error happened.  
  });
}

//stock info per user
function savedState(){
  var user = firebase.auth().currentUser;
  firebase.auth().onAuthStateChanged((user) => {
    if (user) {
      // User is signed in, see docs for a list of available properties
      // https://firebase.google.com/docs/reference/js/firebase.User
      var uid = user.uid;
      // ...
    } else {
      // User is signed out
      // ...
    }
  });
}

function findUser(){
  var user = firebase.auth().currentUser;
  firebaseApp.auth().onAuthStateChanged(user => {
    if (user) {
     const { currentUser } = firebaseApp.auth();
     console.log('Currently logged in user', currentUser);
     store.dispatch(userLoggedIn(currentUser.uid));
     browserHistory.push('/newsfeed');
     // save the current user's uid to redux store.
    } else {
     browserHistory.push('/signin');
     // delete the current user's uid from the redux store.
    }
   })
}

function updatePassword(){
  var user = firebase.auth().currentUser;
var newPassword = getASecureRandomPassword();

user.updatePassword(newPassword).then(function() {
  // Update successful.
}).catch(function(error) {
  // An error happened.
});
}
>>>>>>> Stashed changes
