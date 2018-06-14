package com.outlook.octavio.armenta.tamagotchi9052.web.services

import com.outlook.octavio.armenta.tamagotchi9052.models.Animal
import com.outlook.octavio.armenta.tamagotchi9052.web.messages.MessageRequest
import com.outlook.octavio.armenta.tamagotchi9052.web.messages.MessageResponse
import retrofit2.Call
import retrofit2.http.*


interface AnimalService {

    @GET("animal/{id}")
    fun getSingle(request: MessageRequest<Int>): Call<MessageResponse<Animal>>

    @GET("animal/")
    fun getAll(): Call<MessageResponse<List<Animal>>>

    @POST("animal/")
    fun create(@Body request: MessageRequest<Animal>): MessageResponse<Animal>

    @PUT("animal/{id}")
    fun update(@Path("id") id: String, @Body request: MessageRequest<Animal>): MessageResponse<Animal>

    @DELETE("animal/{id}")
    fun delete(@Path("id") id: String): Call<Unit>

}