import React, { useState, useEffect } from "react";

import "./styles.css";

const regButton = document.getElementById("regBtn");

export default function RegisterInput(props) {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  function postRegisterAttempt() {
    fetch("https://cab230.hackhouse.sh/register", {
      method: "POST",
      body: `email=${encodeURIComponent(email)}&password=${encodeURIComponent(
        password
      )}`,
      headers: {
        "Content-type": "application/x-www-form-urlencoded"
      }
    })
      .then(function(response) {
        if (response.ok) {
          return response.json();
        }
        throw new Error("Network response was not ok");
      })
      .then(function(result) {
        let appDiv = document.getElementById("app");
        appDiv.innerHTML = JSON.stringify(result);
        regButton.disabled = true;
      })
      .catch(function(error) {
        console.log(
          "There has been a problem with your fetch operation: ",
          error.message
        );
      });
  }

  return (
    <div className="App">
      <h2>Register:</h2>
      <form
        onSubmit={event => {
          event.preventDefault();
          //console.log(event.target.elements.name.value);
        }}
      >
        <label htmlFor="name">Email:</label>
        <input
          name="email"
          id="email"
          type="email"
          placeholder="Email address"
          value={email}
          onChange={event => {
            setEmail(event.target.value);
            console.log(email);
          }}
        /> <br /> <br />
        <label htmlFor="name">Password:</label>
        <input
          name="password"
          id="password"
          type="password"
          placeholder="password"
          value={password}
          onChange={event => {
            setPassword(event.target.value);
            console.log(password);
          }}
        /> <br /> <br />
        <button
          onClick={event => {
            postRegisterAttempt();
          }}
          type="submit"
        >
          Submit
        </button>
      </form>
    </div>
  );
}
/*
const regButton = document.getElementById("regBtn");
regButton.addEventListener("click", () => {
  fetch("https://cab230.hackhouse.sh/register", {
    method: "POST",
    body:
      "email=${encodeURIComponent(email)}&password=${encodeURIComponent(password)}",
    headers: {
      "Content-type": "application/x-www-form-urlencoded"
    }
  })
    .then(function(response) {
      if (response.ok) {
        return response.json();
      }
      throw new Error("Network response was not ok");
    })
    .then(function(result) {
      let appDiv = document.getElementById("app");
      appDiv.innerHTML = JSON.stringify(result);
      regButton.disabled = true;
    })
    .catch(function(error) {
      console.log(
        "There has been a problem with your fetch operation: ",
        error.message
      );
    });
});
*/
//const rootElement = document.getElementById("root");
//ReactDOM.render(<RegisterInput />, rootElement);
