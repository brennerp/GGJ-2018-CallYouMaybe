#Character: Granny
VAR calling_character = ""
VAR num_errors = 0
VAR stopped_flown_on = 0
EXTERNAL who_is_being_called()

->start_call

===start_call====
~calling_character = who_is_being_called()

{
- calling_character == "Raissa":
    ->calling_raissa
- calling_character == "Rodrigo":
    ->calling_rodrigo
-calling_character == "Sarue":
    ->calling_sarue
}

===calling_raissa===
    Raissa: Why are you calling me, Gustavo?
    Granny: Huh...
    ->calling_raissa.1st_question

    = 1st_question
        ~stopped_flown_on = 1
        Raissa: Don't just "huh" me. 
        What is it, Gustavo?
        *[I wanted to talk to you.]
        Granny: I wanted to talk to you...
        Raissa: You wanted to TALK to me??? 
        Granny: Yes.
        Raissa: Oh, so now you wanna talk. When I wanted to talk about our relationship you kept avoiding me, but now that it's convinient to you we are gonna talk???
        Granny: Oh no.
        Raissa: "Oh no"? Oh yes. 
        Let's talk, then.
            ->calling_raissa.2nd_question
        *[I just... missed you.]
        Granny: I missed you, thought I might call.
        Raissa: You missed me? That's odd.
        Because I just saw you this morning and as soon as I woke up you left my house like a madman.
        Granny: ...Baby, I was in a hurry then.
            ->calling_raissa.mistake


    = 2nd_question
        ~stopped_flown_on = 2
        Raissa: Everything has to be your way.
        Granny: Oh, man. Okay. That's not entirely truth.
        Raissa: Oh, isn't it? Tell me one time you did something for me that you didn't want to do? 
        Granny: No... I just do what I think will make you happy?
        Raissa: Oh really?
        For instance, do you remember when you asked me if you could leave a FEW things in my place?
        Granny:...Yes?
        Raissa: And you showed up with a 3 feet tall oil painting of yourself. Shirtless.
        Granny: Oh.
        Raissa: Did you do that just because you thought it would make ME happy??
        *[Damn right, I did!]
        Granny: Oh yes! Damn right I did!
        Raissa: What??
        Granny: It's nice to look at your boyfriend's naked torso everyday when you wake up, isn't it?
        Raissa: OH MY GOD! WHAT THE FUCK IS WRONG WITH YOU??
            ->calling_raissa.3rd_question
        *[I was just trying to be cute]
        Granny: Baby, I was just trying to be cute. You know I'm always trying to make you laugh.
        Raissa: Come on, man!
        Granny: I'm so sorry. I didn't mean to bother you.
            ->calling_raissa.mistake
    
     = 3rd_question
        ~stopped_flown_on = 3
        Raissa: You know, I was trying to be nice! I wasn't gonna do it over the phone or anything.
        Raissa: Do you have any idea how much I regret the decision to date you??
        *[YOU'RE A PIECE OF WORK TOO, YOUNG LADY!]
        Granny: OH YEAH? SO FOR YOUR INFORMATION, YOU'RE A PIECE OF WORK TOO, YOUNG LADY.
        Raissa: What??
        Granny: YOUR BOYFRIEND MAY BE A NUTCASE, BUT YOU'RE VERY RUDE AND I'M TOO OLD TO DEAL WITH THIS TEENAGE ANGST.
            ->calling_raissa.transmission
        *[No! Wait! I'm sorry!]
        Granny: I'm sorry! I'm so sorry!
        I didn't mean anything by it. I didn't think you'd get so upset. I didn't mean it.
            ->calling_raissa.mistake
        
        

    = mistake
        ~num_errors = num_errors + 1
        {
            - num_errors >=2:
                ->calling_raissa.bad_end
            - else:
                ->calling_raissa.first_mistake_question
        }
    
    
    = first_mistake_question
      Raissa: Oh... I see.
      Granny: Babe, please. I didn't mean to hurt you. You know that.
      Raissa: Huh... I don't know, Gustavo. 
      I think I'm gonna go...
        *[Come on, Raissa! I gotta talk to you RIGHT NOW.]
        Raissa: Ugh! Why are you like this?
        Granny: What?
            {
                - stopped_flown_on == 1:
                    ->calling_raissa.2nd_question
                - stopped_flown_on == 2:
                    ->calling_raissa.3rd_question
                - stopped_flown_on == 3:
                    ->calling_raissa.transmission
            }
        *[No wait! I love you!]
        Granny: Babe, please wait! You know I love you, right?
        Raissa: Oh man.
        You know this is kinda the problem. I really can't take all this goddamn clingy shit. We've known each other for like 3 weeks, man. Chill out.
        Granny: Oh, no.
        Raissa: You know, this is not working out. I think it's best we end things, Gustavo.
            ->calling_raissa.bad_end
    
    =bad_end
        Granny: Wait, let me explain it to you.
        Raissa: ...
        Raissa: Gustavo, this isn't working.
        Granny: No, Raissa! Let's talk about it!
        Raissa: No, man. See you around.
    #Failure
    ->DONE

    =transmission
        Raissa: Oh man. What is this? I feel weird.
        Granny: What? Is it working?
        Raissa: I don't feel well.
        Granny: It's working!
        #Success
    ->DONE
    
->DONE

===calling_rodrigo===
    Rodrigo: BROOOO!!!
    Granny: Hello!!
    
    
    ->calling_rodrigo.1st_question

    = 1st_question
        ~stopped_flown_on = 1
        Rodrigo: What's up brooo? 
        Granny: What is up??
        Rodrigo: Guess what I'm doing right now!
        *[Nothing at all?]
         Granny: I bet you're doing nothing at all, you... lazy dog.
         Rodrigo: Hahaha! That's a new one! I like it. 
         Bro, I am living the dream. Nothing at all to do all day.
         Just beer, the sea and some bros I met here at the beach.
         Granny: That sounds nice... bro.
            ->calling_rodrigo.2nd_question
        *[Chilling in a hot tub with some hotties?]
        Granny: Just hanging out with some beautiful young ladies in a nice hot tub?
        Rodrigo: Duudeee! What the fuck??
        Granny: Uhh??
        Rodrigo: Do I look like the kind of loser that would waste my sweet sweet vacations doing something like that?
        Granny: Hahahaha! Just messing with you, bro!
            ->calling_rodrigo.mistake


    = 2nd_question
        ~stopped_flown_on = 2
        Rodrigo: But broooo! Did you see the game last night?? 
        Granny: Yes! It was crazy!
        Rodrigo: Man, no one saw the Jaguars coming! Am I right?
        *[What?]
        Granny: The Jaguars?
        Rodrigo: ...
        Rodrigo: PSYCHE! OF COURSE THEY WON!
        Hahaha!
        The Jags ruuuleee. Blake Bortles is a God.
        Granny: Hahaha! He is!
        Rodrigo: And those arms, man! Those fucking arms of gold and pure sweet, sweet, sweeeet muscle.
        Granny: Huh.
        Rodrigo: No homo, though.
        Hahahaha!
            ->calling_rodrigo.3rd_question
        *[Yeah! Who would have guessed!]
        Granny: Who would have thought? Those lousy Jaguars coming all this way?
        Rodrigo: What the fuck man? How dare you speak ill of the Jags!
        Granny: What? But?
        Rodrigo: I was joking with you, bro! What the fuck!
        Granny: I was joking right back at you!
            ->calling_rodrigo.mistake
    
     = 3rd_question
        ~stopped_flown_on = 3
        Rodrigo: Ah, yes. I just remembered! 
        Did you stop by my place to feed Blake?
        Granny: Yeah, of course!
        Rodrigo: Nice! I knew you wouldn't starve my dog, bro! Hahahaha! You know I only give him the best in this life so we can both be thick boys. 
       Granny: ...Yeah. Of course.
       Rodrigo: Did you give him the meal I planned? 
        *[Yep, a nice chicken breast and a protein shake.]
        Granny: I gave him a chicken breast with sweet potatos and a bowl of protein shake.
        Rodrigo: ...
        Hahahaha!
        Good one, bro!
        Granny: Ha ha ha...
        Rodrigo: You're golden, Gustavito. Golden.
            ->calling_rodrigo.transmission
        *[Oh yeah. Just the amount of dog food you told me to give me.]
        Granny: Oh you know, just that measure of dog food you told me.
        Rodrigo: WHAT?
        YOU ARE FEEDING THIS CRAP TO MY BLAKEY?
        GUSTAVO 
        I
        WILL
        SKIN 
        YOU
        AND MAKE YOU INTO A LEATHER COLLAR FOR MY POOR BABY
        Granny: No! It was just a joke, bro! Don't be like that!
        I did it just like you asked!
            ->calling_rodrigo.mistake
        
    


    = mistake
        ~num_errors = num_errors + 1
        {
            - num_errors >=2:
                ->calling_rodrigo.bad_end
            - else:
                ->calling_rodrigo.first_mistake_question
        }
    
    
    = first_mistake_question
        Rodrigo: You better really be fucking kidding me, bro.
        Granny: You know me!
        Rodrigo: Not funny, bro! You're lucky I have a soft spot for my homies! 
        Rodrigo: Even the crazy ass ones.
        Rodrigo: Ah, talking about this! Are you calling me about work?
        *[No! Of course not!]
        Granny: I'd never call you about work like that!
        Rodrigo: Hahaha! That's what I like to hear, bro...
            {
                - stopped_flown_on == 1:
                    ->calling_rodrigo.2nd_question
                - stopped_flown_on == 2:
                    ->calling_rodrigo.3rd_question
                - stopped_flown_on == 3:
                    ->calling_rodrigo.transmission
            }
        *[Yeah! It's really important.]
        Granny: Something came up on the tech startup. The one we work together in?
        Rodrigo: Yeah, I know which one, dumbass. 
        You know I told you not to call me about work during my vacation.
        Granny: But it's important.
        Rodrigo: NO CALLING, BRO.
            ->calling_rodrigo.bad_end
    
    =bad_end
        Rodrigo: This is not cool, bro. And I don't have time for this bullshit!
        Granny: No, hold on!
        Rodrigo: NOT COOL.
        BYE, GUSTAVITOOOO.
        #Failure
    ->DONE

    =transmission
        Rodrigo: Ugh, broooo. Fuck, I think I drank too much.
        I don't feel very well.
        Granny: Oh dear! It actually works!
        #Success
    ->DONE
->DONE

===calling_sarue===
    Granny: ...Hello? This is Gustavo speaking.
    
    Sarue: Gustavo? Hahaha, oh boy.
    I dunno how to tell ya, but I don't know no Gustavo, I don't think. 
    
    Granny: No, of course you do!
    
    Sarue: Oh! You mean Gustavo who lived here when we were kids?
    
    Granny: Yes, man! You remember me!
    
    ->calling_sarue.1st_question

    = 1st_question
        ~stopped_flown_on = 1
        Sarue: Oh yes. The Gustavo who shot me with an arrow in the chest when we were 10, right?
        *[Of course! Yeah, man, that day was fun!]
            Granny: Yes, that day was ridiculous. Good old days, huh?
            Sarue: Oh, yes. They were. They sure were!
            ->calling_sarue.2nd_question
        *[What? An arrow? No, the other Gustavo!]
            Granny: I'm the other Gustavo. Come on, man, I'm not that douchebag who shot you. We're friends, I'd never hurt you like that.
           Sarue: Wait, what? We would play like that all the time. Friendly arrow shootin' .
           The day that arrow got stuck in my chest we laughed until our mamas came screaming after us.
            Granny: What? 
            I mean, ahh. I ah. Yeah, of course! I remember that! Haha!
            ->calling_sarue.mistake


    = 2nd_question
        ~stopped_flown_on = 2
        Sarue: It's been so long! I think the last time we spoke was ages ago. 
        Granny: Oh yes, absolutely. 
        Sarue: You moved to the city and never looked back. Big dreams, I get it. Why were you in town that time anyway? 
        
        *[I don't know, I missed the town?]
            Granny: I just missed the town. You know how the city gets on the nerves sometimes.
            Sarue: It sure does! You'd do good to come down here more often.
            Granny: Yes, I really gotta take the time to do it.
            ->calling_sarue.3rd_question
        *[Had to see my mom.]
            Granny: My mom was sick. I had to take a trip down there to see her.
            Sarue: Your mom?? Gustavo, your mom up left when we were little. It was the talk of the town.
            What the fuck are you talking about?
            Granny: Oh no, I mean I found her in a nearby town a couple of years ago. I stop by our town just on my way there.
            Sarue: What?
            ->calling_sarue.mistake
    
     = 3rd_question
        ~stopped_flown_on = 3
        Sarue: Listen man, I gotta say. I never expected you to be calling me. Not after you decided to leave town and go play with that tech stuff.
        Granny: Yeah. That takes a lot of time. Working on tech. And doing...
        Computers? 
        What is it that you do there anyway?
        *[My startup is gonna change the world]
        Granny: I'm gonna change the way people use computers, man.
        Sarue: Hahahaha. You were always a damn lunatic, Gustavo. 
        Granny: You know me. 
        Granny: Gustavo. 
        Granny: Your arrow shootin' friend.
        Granny: ...working in tech and stuff...
            ->calling_sarue.transmission
        *[It's really complicated.]
        Granny: I'd just bore you, really. It's so... technical and all...
        Sarue: Oh yea? So you think you're smarter than me? Just because you went to college and all that?
        Sarue: We all thought you were full of it. Goin' to the big city, acting like you're better than us. 
        Granny: No, I didn't mean it like that. It's just that work here is very stressful with all the computers and...
        Granny: those... intelligent phones?
            ->calling_sarue.mistake
        

        
        

    = mistake
        
        ~num_errors = num_errors + 1
        {
            - num_errors >=2:
                ->calling_sarue.bad_end
            - else:
                ->calling_sarue.first_mistake_question
        }
    
    
    = first_mistake_question
        Sarue: Yeah, ok. You damn weirded me out right there, friend.
        Sarue: Damn crazy talking. But you're always a bit funny in the head, weren't you?
        Granny: Uhh... yes?
        Sarue: Remember that time we were ridin' that old bike of yours? I think we fell off the bridge right into the river.
        Granny: That was so...fun. 
        Sarue: Hahaha it was! Your old man was so crossed we lost his... Oh damn, what was it? He was so angry, he wouldn't let us play for a month.
        Sarue: What was it we lost in the fall? 
        *[...was it his hat?]
            Granny: You know what. I'm not sure if I remember. But I think it was that old hat of his.
            Sarue: Hahaha. I don't even remember. Your dad was a piece of work, he was.
            {
                - stopped_flown_on == 1:
                    ->calling_sarue.2nd_question
                - stopped_flown_on == 2:
                    ->calling_sarue.3rd_question
                - stopped_flown_on == 3:
                    ->calling_sarue.transmission
            }
        *[Oh yes! It was his favourite gun, wasn't it?]
            Granny: Yeah, I remember that. I think I was carrying his gun that day, right? We lost the damn thing in the river.
            Sarue: What the heck is wrong with you man? 
            Sarue: A gun? 
            Sarue: I don't know no man crazy enough to let a kid running around with a damn gun!
            ->calling_sarue.bad_end
    
    =bad_end
        Sarue: Yeah right. You think you're funny, don't you. Wasting people's time with this ridiculous shit.
        Sarue: Good day to you, sir!
        #Failure
    ->DONE

    =transmission
        Sarue: Ugh!
        Sarue: I don't feel so good...
        Granny: Oh dear! It's actually working!
        #Success
    ->DONE
->DONE

