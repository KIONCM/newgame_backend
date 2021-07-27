package com.game.realplayer.controller;

import com.game.realplayer.entity.PlayerRegistrationRequest;
import com.game.realplayer.service.PlayerRegistrationService;
import lombok.AllArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("player")
@AllArgsConstructor
public class RegistrationController {
    private final PlayerRegistrationService playerRegistrationService;

    @PostMapping("new")
    public HttpStatus register(@RequestBody PlayerRegistrationRequest request){
         playerRegistrationService.register(request);
         return HttpStatus.ACCEPTED;
    }

}
