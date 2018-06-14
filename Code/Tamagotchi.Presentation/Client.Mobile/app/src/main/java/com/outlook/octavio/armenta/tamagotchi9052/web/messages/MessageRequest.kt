package com.outlook.octavio.armenta.tamagotchi9052.web.messages


data class MessageRequest<T>(val body: T, val token: String)