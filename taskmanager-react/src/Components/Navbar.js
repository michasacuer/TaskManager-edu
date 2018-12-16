import React, { Component } from "react";
import { Navbar } from "react-bootstrap";

class NavBar extends Component {
  render() {
    return (
      <Navbar inverse collapseOnSelect>
        <Navbar.Collapse>
          <Navbar.Form>
            <Navbar.Brand onClick={this.props.toggleProjects}>
              Projekty
            </Navbar.Brand>
            <Navbar.Form>
              <Navbar.Brand href="#">Użytkownicy</Navbar.Brand>
            </Navbar.Form>
          </Navbar.Form>
          <Navbar.Form pullRight>
            <Navbar.Brand>Wyloguj się</Navbar.Brand>
          </Navbar.Form>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}

export default NavBar;
