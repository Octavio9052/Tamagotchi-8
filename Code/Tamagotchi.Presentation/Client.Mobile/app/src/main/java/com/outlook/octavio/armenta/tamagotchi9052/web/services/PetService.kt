package com.outlook.octavio.armenta.tamagotchi9052.web.services

import com.outlook.octavio.armenta.tamagotchi9052.models.Pet
import com.outlook.octavio.armenta.tamagotchi9052.web.messages.MessageRequest
import com.outlook.octavio.armenta.tamagotchi9052.web.messages.MessageResponse
import retrofit2.Call
import retrofit2.http.*


interface PetService {

    @GET("pet/{id}")
    fun getSingle(request: MessageRequest<Int>): Call<MessageResponse<Pet>>

    @GET("pet/")
    fun getAll(): Call<MessageResponse<List<Pet>>>

    @POST("pet/")
    fun create(@Body request: MessageRequest<Pet>): MessageResponse<Pet>

    @PUT("pet/{id}")
    fun update(@Path("id") id: String, @Body request: MessageRequest<Pet>): MessageResponse<Pet>

    @DELETE("pet/{id}")
    fun delete(@Path("id") id: String): Call<Unit>

}