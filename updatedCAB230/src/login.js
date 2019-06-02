import React, { useState, useEffect } from "react";

import "./styles.css";
import "./index.js";

export default function LoginInput(props) {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  function loginAttempt() {
    fetch("https://cab230.hackhouse.sh/login", {
      method: "POST",
      // body: `email=${encodeURIComponent(email)}&password=${encodeURIComponent(
      //   password
      // )}`,
      body: `email=g@g&password=gg`,
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
        global.JWT = result.token;
        console.log("login success");
        console.log(global.JWT);
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
      <h2>Login:</h2>
      <form
        onSubmit={event => {
          event.preventDefault();
          //console.log(event.target.elements.name.value);
        }}
      >
        {/* <label htmlFor="name">Email:</label> */}
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
        {/* <label htmlFor="name">Password:</label> */}
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
            loginAttempt();
            props.onLogin(global.JWT);
            console.log("token" + global.JWT);
            // make_a_login_function_like_the_example();
            /* WITHIN THIS FUNCTION YOU WILL SET THE TOKEN ONCE THE fetch RETURNS OK
            you do this by using props.onLogin(response.token)
            */
          }}
          type="submit"
        >
          Login
        </button>
      </form>
    </div>
  );
}
