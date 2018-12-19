import {
  Button,
  Radio,
  Col,
  FormGroup,
  FormControl,
  ControlLabel
} from "react-bootstrap";
import React, { Component } from "react";
import "../../Styles/Forms.css";
import ApiController from "../Helpers/ApiController";
import Validator from "../Helpers/Validator";

class AddProject extends Component {
  constructor(props, context) {
    super(props, context);

    this.state = {
      login: "",
      password: "",
      firstname: "",
      lastname: "",
      email: "",
      position: -1
    };
  }

  submit() {
    if (this.state.login.length < 3) {
      window.alert("Wprowadź poprawny login!");
      return;
    }
    if (!Validator.check(this.state.password).hasNumber()) {
      window.alert("Hasło powinno zawierać liczbę!");
      return;
    }
    if (!Validator.check(this.state.email).isEmailValid()) {
      window.alert("Adres email jest niepoprawny!");
      return;
    }
    if (this.state.emailposition === -1) {
      window.alert("Zaznacz pozycję pracownika!");
      return;
    }
    this.setState({
      firstname: Validator.check(this.state.firstname).firstLetterCapital()
    });
    this.setState({
      lastname: Validator.check(this.state.lastname).firstLetterCapital()
    });
    ApiController.api("Users").post(this.state);
  }

  getValidationStateLogin() {
    const length = this.state.login.length;
    if (length > 3) return "success";
    else if (length > 0) return "error";
    return;
  }

  handleChangeLogin(e) {
    this.setState({ login: e.target.value });
  }

  handleChangePass(e) {
    this.setState({ password: e.target.value });
  }

  handleChangefirstName(e) {
    this.setState({ firstname: e.target.value });
  }

  handleChangelastName(e) {
    this.setState({ lastname: e.target.value });
  }

  handleChangeEmail(e) {
    this.setState({ email: e.target.value });
  }

  handleChangePosition(e) {
    this.setState({ position: e.target.value });
  }

  render() {
    return (
      <form className="text" horizontal="true">
        <FormGroup
          controlId="formBasicLogin"
          validationState={this.getValidationStateLogin()}
        >
          <ControlLabel>Login</ControlLabel>
          <FormControl
            type="text"
            login={this.state.login}
            placeholder="Podaj Login"
            onChange={this.handleChangeLogin.bind(this)}
          />
          <FormControl.Feedback />
        </FormGroup>
        <FormGroup controlId="formBasicPass">
          <ControlLabel>Hasło</ControlLabel>
          <FormControl
            type="password"
            password={this.state.password}
            placeholder="Podaj opis projektu"
            onChange={this.handleChangePass.bind(this)}
          />
        </FormGroup>
        <FormGroup controlId="formBasicfirstName">
          <ControlLabel>Imię</ControlLabel>
          <FormControl
            type="text"
            firstname={this.state.firstname}
            placeholder="Podaj Imię"
            onChange={this.handleChangefirstName.bind(this)}
          />
          <FormControl.Feedback />
        </FormGroup>
        <FormGroup controlId="formBasiclastname">
          <ControlLabel>Nazwisko</ControlLabel>
          <FormControl
            type="text"
            lastname={this.state.lastname}
            placeholder="Podaj nazwisko"
            onChange={this.handleChangelastName.bind(this)}
          />
          <FormControl.Feedback />
        </FormGroup>
        <FormGroup controlId="formBasicEmail">
          <ControlLabel>Email</ControlLabel>
          <FormControl
            type="text"
            email={this.state.email}
            placeholder="Podaj email"
            onChange={this.handleChangeEmail.bind(this)}
          />
          <FormControl.Feedback />
        </FormGroup>
        <FormGroup onChange={this.handleChangePosition.bind(this)}>
          <Radio defaultValue={0} name="radioGroup" inline>
            Manager
          </Radio>{" "}
          <Radio defaultValue={1} name="radioGroup" inline>
            Developer
          </Radio>{" "}
          <Radio defaultValue={2} name="radioGroup" inline>
            Viewer
          </Radio>
        </FormGroup>
        <FormGroup>
          <Col smOffset={2} sm={10}>
            <Button
              className="succes-button"
              bsStyle="success"
              onClick={this.submit.bind(this)}
            >
              Dodaj użytkownika
            </Button>
          </Col>
        </FormGroup>
      </form>
    );
  }
}

export default AddProject;
