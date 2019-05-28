import React, { useState, useEffect } from "react";
import ReactDOM from "react-dom";
import RegisterInput from "./register";
import Main from "./main";
import LoginInput from "./login";
import SearchInput from "./search";

import "./styles.css";

global.JWT = null;
let userEmail = null;
let userPassword = null;

function App() {
  const [token, setToken] = useState(null); //WILL USE TOKEN TO TELL IF USER IS LOGGED IN
  const onLogin = JWT => setToken(JWT); // THIS FUNCTION WILL APPLY t (token) to the state
  const onLogout = () => setToken(null); // THIS FUNCTION WILL APPLY null to the state, removing the token

  return (
    <div className="Register">
      <RegisterInput />
      {global.JWT == null ? (
        <LoginInput onLogin={onLogin} />
      ) : (
        <Main token={token} onLogout={onLogout} />
      )}
      <SearchInput />
    </div>
  );
}

const rootElement = document.getElementById("root");
ReactDOM.render(<App />, rootElement);
/*
const logButton = document.getElementById("logBtn");
logButton.addEventListener("click", () => {
  fetch("https://cab230.hackhouse.sh/login", {
    method: "POST",
    body: "email=doggie%40mail.com&password=woof",
    headers: {
      "Content-type": "application/x-www-form-urlencoded"
    }
  })
    .then(function(response) {
      if (response.ok) {
        return response.json();
      }
      throw new Error("Network response was not ok.");
    })
    .then(function(result) {
      let appDiv = document.getElementById("app");
      appDiv.innerHTML = JSON.stringify(result);
      JWT = result.token;
    })
    .catch(function(error) {
      console.log(
        "There has been a problem with your fetch operation: ",
        error.message
      );
    });
});
*/
const offButton = document.getElementById("offBtn");
offButton.addEventListener("click", () => {
  fetch("https://cab230.hackhouse.sh/offences")
    .then(function(response) {
      if (response.ok) {
        return response.json();
      }
      throw new Error("Network response was not ok.");
    })
    .then(function(result) {
      let appDiv = document.getElementById("app");
      appDiv.innerHTML = JSON.stringify(result);
    })
    .catch(function(error) {
      console.log(
        "There has been a problem with your fetch operation: ",
        error.message
      );
    });
});
/*
const searchButton = document.getElementById("serBtn");
searchButton.addEventListener("click", () => {
  //The parameters of the call
  let getParam = { method: "GET" };
  let head = { Authorization: `Bearer ${JWT}` };
  getParam.headers = head;

  //The URL
  const baseUrl = "https://cab230.hackhouse.sh/search?";
  const query = "offence=Armed Robbery";
  const url = baseUrl + query;

  fetch(encodeURI(url), getParam)
    .then(function(response) {
      if (response.ok) {
        return response.json();
      }
      throw new Error("Network response was not ok.");
    })
    .then(function(result) {
      let appDiv = document.getElementById("app");
      appDiv.innerHTML = JSON.stringify(result);
    })
    .catch(function(error) {
      console.log(
        "There has been a problem with your fetch operation: ",
        error.message
      );
    });
});

const filterDiv = document.getElementById("filter");
filterDiv.addEventListener("click", event => {
  const param = event.target.innerHTML;
  let filter = "";

  //Example filter strings
  if (param === "area") {
    filter = "area=Moreton Bay Regional Council";
  } else if (param === "age") {
    filter = "age=Juvenile";
  } else if (param === "year") {
    filter = "year=2006,2007,2008";
  }

  //The parameters of the call
  let getParam = { method: "GET" };
  let head = { Authorization: `Bearer ${JWT}` };
  getParam.headers = head;

  //The URL
  const baseUrl = "https://cab230.hackhouse.sh/search?";
  const query = "offence=Armed Robbery";

  const url = baseUrl + query + "&" + filter;

  fetch(encodeURI(url), getParam)
    .then(function(response) {
      if (response.ok) {
        return response.json();
      }
      throw new Error("Network response was not ok.");
    })
    .then(function(result) {
      let appDiv = document.getElementById("app");
      appDiv.innerHTML = JSON.stringify(result);
    })
    .catch(function(error) {
      console.log(
        "There has been a problem with your fetch operation: ",
        error.message
      );
    });
});
*/
