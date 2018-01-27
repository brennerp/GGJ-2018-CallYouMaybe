#Character: OldLady
VAR calling_character = ""
VAR num_errors = 0
VAR stopped_flown_on = 0
EXTERNAL who_is_being_called()

->start_call

===start_call====
~calling_character = who_is_being_called()

{
- calling_character == "raissa":
    ->calling_raissa
- calling_character == "rodrigo":
    ->calling_rodrigo
-calling_character == "sarue":
    ->calling_sarue
}

===calling_raissa===
    Hello!
    
    ->calling_raissa.1st_question

    = 1st_question
        ~stopped_flown_on = 1
        this is the first question. How do you answer?
        *[Really well!]
            ->calling_raissa.2nd_question
        *[Really baddly!]
            ->calling_raissa.mistake


    = 2nd_question
        ~stopped_flown_on = 2
        this is the second question. How do you answer?
        *[Really well!]
            ->calling_raissa.3rd_question
        *[Really baddly!]
            ->calling_raissa.mistake
    
     = 3rd_question
        ~stopped_flown_on = 3
        this is the third question. How do you answer?
        *[Really well!]
            ->calling_raissa.4th_question
        *[Really baddly!]
            ->calling_raissa.mistake
        
    
    = 4th_question
        ~stopped_flown_on = 4
        this is the last question. How do you answer?
        *[Really well!]
            ->calling_raissa.transmission
        *[Really baddly!]
            ->calling_raissa.mistake
        
        

    = mistake
        Wrong bitch!
        ~num_errors = num_errors + 1
        {
            - num_errors >=2:
                ->calling_raissa.bad_end
            - else:
                ->calling_raissa.first_mistake_question
        }
    
    
    = first_mistake_question
        What the fuck man. What the hell do you want?
        *[I want the right thing, apparently]
            {
                - stopped_flown_on == 1:
                    ->calling_raissa.2nd_question
                - stopped_flown_on == 2:
                    ->calling_raissa.3rd_question
                - stopped_flown_on == 3:
                    ->calling_raissa.4th_question
            }
        *[I want the wrong thing cos I'm dumb]
            ->calling_raissa.bad_end
    
    =bad_end
        Oh fuck you, bye bitch.
    ->DONE

    =transmission
        Ok we're doing the transmission then!
    ->DONE
    
->DONE

===calling_rodrigo===
    Hello!
    
    ->calling_rodrigo.1st_question

    = 1st_question
        ~stopped_flown_on = 1
        this is the first question. How do you answer?
        *[Really well!]
            ->calling_rodrigo.2nd_question
        *[Really baddly!]
            ->calling_rodrigo.mistake


    = 2nd_question
        ~stopped_flown_on = 2
        this is the second question. How do you answer?
        *[Really well!]
            ->calling_rodrigo.3rd_question
        *[Really baddly!]
            ->calling_rodrigo.mistake
    
     = 3rd_question
        ~stopped_flown_on = 3
        this is the third question. How do you answer?
        *[Really well!]
            ->calling_rodrigo.4th_question
        *[Really baddly!]
            ->calling_rodrigo.mistake
        
    
    = 4th_question
        ~stopped_flown_on = 4
        this is the last question. How do you answer?
        *[Really well!]
            ->calling_rodrigo.transmission
        *[Really baddly!]
            ->calling_rodrigo.mistake
        
        

    = mistake
        Wrong bitch!
        ~num_errors = num_errors + 1
        {
            - num_errors >=2:
                ->calling_rodrigo.bad_end
            - else:
                ->calling_rodrigo.first_mistake_question
        }
    
    
    = first_mistake_question
        What the fuck man. What the hell do you want?
        *[I want the right thing, apparently]
            {
                - stopped_flown_on == 1:
                    ->calling_rodrigo.2nd_question
                - stopped_flown_on == 2:
                    ->calling_rodrigo.3rd_question
                - stopped_flown_on == 3:
                    ->calling_rodrigo.4th_question
            }
        *[I want the wrong thing cos I'm dumb]
            ->calling_rodrigo.bad_end
    
    =bad_end
        Oh fuck you, bye bitch.
    ->DONE

    =transmission
        Ok we're doing the transmission then!
    ->DONE
->DONE

===calling_sarue===
    Hello!
    
    ->calling_sarue.1st_question

    = 1st_question
        ~stopped_flown_on = 1
        this is the first question. How do you answer?
        *[Really well!]
            ->calling_sarue.2nd_question
        *[Really baddly!]
            ->calling_sarue.mistake


    = 2nd_question
        ~stopped_flown_on = 2
        this is the second question. How do you answer?
        *[Really well!]
            ->calling_sarue.3rd_question
        *[Really baddly!]
            ->calling_sarue.mistake
    
     = 3rd_question
        ~stopped_flown_on = 3
        this is the third question. How do you answer?
        *[Really well!]
            ->calling_sarue.4th_question
        *[Really baddly!]
            ->calling_sarue.mistake
        
    
    = 4th_question
        ~stopped_flown_on = 4
        this is the last question. How do you answer?
        *[Really well!]
            ->calling_sarue.transmission
        *[Really baddly!]
            ->calling_sarue.mistake
        
        

    = mistake
        Wrong bitch!
        ~num_errors = num_errors + 1
        {
            - num_errors >=2:
                ->calling_sarue.bad_end
            - else:
                ->calling_sarue.first_mistake_question
        }
    
    
    = first_mistake_question
        What the fuck man. What the hell do you want?
        *[I want the right thing, apparently]
            {
                - stopped_flown_on == 1:
                    ->calling_sarue.2nd_question
                - stopped_flown_on == 2:
                    ->calling_sarue.3rd_question
                - stopped_flown_on == 3:
                    ->calling_sarue.4th_question
            }
        *[I want the wrong thing cos I'm dumb]
            ->calling_sarue.bad_end
    
    =bad_end
        Oh fuck you, bye bitch.
    ->DONE

    =transmission
        Ok we're doing the transmission then!
    ->DONE
->DONE

