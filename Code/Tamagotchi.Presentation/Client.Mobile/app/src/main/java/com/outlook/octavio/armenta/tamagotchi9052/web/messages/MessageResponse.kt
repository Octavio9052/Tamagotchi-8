package com.outlook.octavio.armenta.tamagotchi9052.web.messages

data class MessageResponse<T>(val body: T, val error: String)