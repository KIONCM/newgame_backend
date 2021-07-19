package com.game.realplayer.player.registration;

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
    private final RegistrationService registrationService;

    @PostMapping("new")
    public HttpStatus register(@RequestBody RegistrationRequest request){
         registrationService.register(request);
         return HttpStatus.ACCEPTED;
    }

}
