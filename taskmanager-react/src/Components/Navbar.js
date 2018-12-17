import React, { Component } from "react";
import { Navbar, NavItem, Nav } from "react-bootstrap";
import "../Styles/Navbar.css";

class NavBar extends Component {
  render() {
    return (
      <div>
        <Navbar inverse collapseOnSelect>
          <a href="/" h1 className="Navbar-header-text">
            miniJira
          </a>
          <p />
          <Navbar.Header>
            <Navbar.Brand>
              <a href="/projects">Projekty</a>
            </Navbar.Brand>
            <Navbar.Toggle />
          </Navbar.Header>
          <Navbar.Header>
            <Navbar.Brand>
              <a href="/users">Użytkownicy</a>
            </Navbar.Brand>
            <Navbar.Toggle />
          </Navbar.Header>
          <Nav pullRight>
            <NavItem eventKey={1} href="#">
              Wyloguj się
            </NavItem>
          </Nav>
        </Navbar>
      </div>
    );
  }
}

export default NavBar;
