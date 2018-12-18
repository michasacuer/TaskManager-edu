import React, { Component } from "react";
import { ListGroup, Button } from "react-bootstrap";
import { Link } from "react-router-dom";
import "../../Styles/Projects.css";

const button = props => {
  return (
    <div>
      <Link to={props.link}>
        <Button className="succes-button" bsStyle="success">
          {props.buttonTitle}
        </Button>
      </Link>
    </div>
  );
};

export default button;
