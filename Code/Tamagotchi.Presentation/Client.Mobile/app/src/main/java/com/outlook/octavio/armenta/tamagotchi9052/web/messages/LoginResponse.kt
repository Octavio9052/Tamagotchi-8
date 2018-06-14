package com.outlook.octavio.armenta.tamagotchi9052.web.messages

import com.outlook.octavio.armenta.tamagotchi9052.models.User

/**
 * @author J. Pichardo
 */
data class LoginResponse(val user: User, val token: String, val error: String)
