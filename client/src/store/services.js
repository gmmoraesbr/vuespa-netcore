import Axios from 'axios'
import userService from '../services/UserService'
import figureService from '../services/FigureService'
import figureUserService from '../services/FigureUserService'

let apiUrl = 'http://localhost:59541/'

// Axios Configuration
Axios.defaults.headers.common.Accept = 'application/json'

export default {
    userService: new userService(Axios, apiUrl),
    figureService: new figureService(Axios, apiUrl),
    figureUserService: new figureUserService(Axios, apiUrl)
}