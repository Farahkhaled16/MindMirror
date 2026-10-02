namespace MindMirror.Models;

public static class ConditionData
{
    public static Condition? Find(string slug) =>
        All.FirstOrDefault(c => c.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase));

    public static readonly List<Condition> All = new()
    {
        new Condition
        {
            Slug = "depression", Name = "Depression", Icon = "🌧️",
            Summary = "Persistent low mood or loss of interest that affects daily life.",
            Overview = "Depression is a common and treatable medical condition. It is more than feeling sad for a few days: the low mood or loss of interest lasts most of the day, nearly every day, for at least two weeks, and it affects work, study, and relationships. It is not a weakness or a personal failure.",
            Signs = new[] {
                "Feeling sad, empty, hopeless, or numb",
                "Losing interest in things you used to enjoy",
                "Changes in sleep (too little or too much) and appetite",
                "Low energy, tiredness, or moving and thinking more slowly",
                "Difficulty concentrating or making decisions",
                "Feeling worthless or excessively guilty",
                "Thoughts of death or of hurting yourself (seek help right away)" },
            Causes = new[] {
                "A mix of biology, genetics, life events, and personality",
                "Loss, long-term stress, trauma, or major life changes",
                "Other health problems, some medications, or hormonal changes",
                "A family history of depression increases risk, but does not decide your future" },
            Treatment = new[] {
                "Talk therapy, such as cognitive behavioural therapy (CBT) or interpersonal therapy",
                "Antidepressant medication, prescribed and monitored by a doctor",
                "A combination of therapy and medication for moderate to severe depression",
                "Support for sleep, activity, and social connection alongside treatment" },
            SelfHelp = new[] {
                "Keep a basic routine: wake time, meals, and a short daily walk",
                "Do one small, manageable thing at a time instead of waiting to feel motivated",
                "Stay in touch with at least one person you trust",
                "Limit alcohol, which tends to worsen mood" },
            Support = new[] {
                "Listen without rushing to fix or judge",
                "Avoid phrases like \"cheer up\" or \"others have it worse\"",
                "Offer practical help and gently encourage seeing a professional" },
            SeekHelp = "Talk to a doctor or mental health professional if low mood lasts two weeks or more, or sooner if it interferes with daily life. If you have thoughts of ending your life, contact emergency services or someone you trust right away."
        },
        new Condition
        {
            Slug = "generalized-anxiety", Name = "Generalized Anxiety", Icon = "🌀",
            Summary = "Excessive, hard-to-control worry about many everyday things.",
            Overview = "Everyone worries sometimes. Generalized anxiety disorder (GAD) involves persistent worry on most days for six months or more, about many areas of life, that feels hard to control and affects how you function.",
            Signs = new[] {
                "Constant worry, even when there is little reason",
                "Feeling restless, on edge, or keyed up",
                "Muscle tension, headaches, or stomach problems",
                "Getting tired easily and trouble concentrating",
                "Irritability",
                "Trouble falling or staying asleep" },
            Causes = new[] {
                "Genetics and temperament",
                "Long-term stress or difficult life experiences",
                "Overlap with depression, health conditions, or too much caffeine",
                "Learned patterns of expecting the worst" },
            Treatment = new[] {
                "CBT, which helps you challenge worry patterns and face avoided situations",
                "Medication such as SSRIs or SNRIs, when a doctor recommends it",
                "Relaxation and breathing skills as a support, not a replacement" },
            SelfHelp = new[] {
                "Set aside a short \"worry time\" and postpone worries to it",
                "Reduce caffeine and keep a regular sleep schedule",
                "Move your body regularly",
                "Try slow breathing (see the Breathe page)" },
            Support = new[] {
                "Reassuring again and again can keep anxiety going. Be calm, kind, and encourage coping skills",
                "Encourage treatment without dismissing their feelings" },
            SeekHelp = "See a professional if worry is constant, hard to control, or limits your sleep, work, study, or relationships."
        },
        new Condition
        {
            Slug = "panic-disorder", Name = "Panic Attacks & Panic Disorder", Icon = "💓",
            Summary = "Sudden waves of intense fear with strong physical symptoms.",
            Overview = "A panic attack is a sudden surge of intense fear that peaks within minutes. It feels frightening, but it is not dangerous in itself. Panic disorder is when attacks keep happening and you start to fear the next one or avoid places because of it.",
            Signs = new[] {
                "Racing or pounding heart",
                "Shortness of breath, chest tightness, or dizziness",
                "Sweating, shaking, tingling, or nausea",
                "Feeling detached or unreal",
                "Fear of losing control or of something terrible happening",
                "Avoiding places or activities where an attack happened" },
            Causes = new[] {
                "Genetics and a sensitive stress response",
                "Periods of heavy stress or life change",
                "Caffeine, certain substances, or medical conditions in some people" },
            Treatment = new[] {
                "CBT with gradual exposure to feared sensations and situations",
                "Medication in some cases, decided with a doctor",
                "Learning what panic is, which reduces fear of it" },
            SelfHelp = new[] {
                "Remind yourself: this will pass, usually within minutes",
                "Slow your breathing: in through the nose, out slowly through the mouth",
                "Ground yourself by naming things you can see, hear, and touch",
                "Avoid avoiding: gradually return to places you've been staying away from" },
            Support = new[] {
                "Stay calm and speak slowly",
                "Do not tell them to \"calm down\". Offer a quiet space and help with breathing" },
            SeekHelp = "Chest pain and breathlessness can also have physical causes. If it is your first attack, or you are unsure, get a medical check. See a professional if attacks keep happening or you are avoiding normal life."
        },
        new Condition
        {
            Slug = "social-anxiety", Name = "Social Anxiety", Icon = "🫥",
            Summary = "Intense fear of being judged or embarrassed around other people.",
            Overview = "Social anxiety is more than shyness. It is a strong, lasting fear of social situations where you might be judged, and it can lead to avoiding school, work, or friendships.",
            Signs = new[] {
                "Dreading social events well in advance",
                "Fear of blushing, shaking, or saying something \"wrong\"",
                "Avoiding speaking in class or meetings, or eating in front of others",
                "Replaying conversations afterward and criticising yourself",
                "Physical symptoms such as sweating or a racing heart" },
            Causes = new[] {
                "Genetics and a naturally cautious temperament",
                "Past bullying, rejection, or embarrassment",
                "Learned beliefs that others are always judging you" },
            Treatment = new[] {
                "CBT with gradual exposure to feared situations",
                "Group therapy or social skills practice",
                "Medication in some cases, with a doctor" },
            SelfHelp = new[] {
                "Make a ladder of small steps, from easiest to hardest, and climb it slowly",
                "Focus on the other person instead of monitoring yourself",
                "Notice that most people are thinking about themselves, not judging you" },
            Support = new[] {
                "Do not push them into situations suddenly",
                "Celebrate small steps and be patient" },
            SeekHelp = "Seek help if fear of others stops you from studying, working, or making friends."
        },
        new Condition
        {
            Slug = "ocd", Name = "Obsessive-Compulsive Disorder (OCD)", Icon = "🔁",
            Summary = "Unwanted, distressing thoughts and repetitive behaviours used to relieve them.",
            Overview = "OCD involves obsessions (intrusive thoughts, images, or urges that cause distress) and compulsions (actions or mental rituals done to reduce that distress). It takes up a lot of time and is not about being \"tidy\" or \"perfectionist\". Having unwanted thoughts does not mean you want to act on them.",
            Signs = new[] {
                "Repeated fears about contamination, harm, mistakes, or things being \"just right\"",
                "Washing, checking, counting, or arranging many times",
                "Mental rituals such as repeating phrases or reviewing events",
                "Seeking reassurance again and again",
                "Spending an hour or more a day on these thoughts and actions" },
            Causes = new[] {
                "Genetics and differences in brain circuits",
                "Stressful events can trigger or worsen symptoms",
                "Sometimes begins in childhood or the teen years" },
            Treatment = new[] {
                "Exposure and response prevention (ERP), a type of CBT, is the main therapy",
                "SSRIs or related medication, prescribed by a doctor",
                "Treatment works well when started early" },
            SelfHelp = new[] {
                "Learn to see obsessions as \"OCD thoughts\", not facts",
                "Try to delay or reduce compulsions a little at a time, ideally with a therapist's guidance",
                "Avoid constantly seeking reassurance" },
            Support = new[] {
                "Do not take part in rituals or give endless reassurance. Be kind but consistent",
                "Remember the person is distressed, not being difficult" },
            SeekHelp = "See a professional if thoughts or rituals take up a lot of time or cause distress. OCD rarely goes away on its own, but it is very treatable."
        },
        new Condition
        {
            Slug = "ptsd", Name = "Trauma & PTSD", Icon = "🕯️",
            Summary = "Lasting distress after a frightening or deeply harmful experience.",
            Overview = "After a traumatic event, many people have strong reactions that ease over weeks. Post-traumatic stress disorder (PTSD) is when symptoms last more than a month and interfere with life. It can follow accidents, violence, abuse, war, disasters, or sudden loss.",
            Signs = new[] {
                "Intrusive memories, nightmares, or flashbacks",
                "Avoiding reminders of the event",
                "Negative thoughts about yourself or the world, guilt, or feeling numb",
                "Being constantly on guard, easily startled, or irritable",
                "Trouble sleeping or concentrating" },
            Causes = new[] {
                "Experiencing, witnessing, or learning about a serious threat or harm",
                "Repeated or long-term trauma raises the risk",
                "Lack of support afterward can make recovery harder" },
            Treatment = new[] {
                "Trauma-focused therapy, such as trauma-focused CBT or EMDR",
                "Medication for related symptoms such as depression or anxiety, with a doctor",
                "Safe, steady support from people you trust" },
            SelfHelp = new[] {
                "Use grounding: name five things you can see, four you can touch, three you can hear",
                "Keep a routine for sleep, food, and movement",
                "Go at your own pace. You don't have to tell your story before you're ready",
                "Limit alcohol and other substances" },
            Support = new[] {
                "Let them decide what and when to share",
                "Be patient with anger, withdrawal, or startle reactions",
                "Offer safety and predictability" },
            SeekHelp = "Seek help if symptoms last longer than a month, are getting worse, or if you feel unsafe or have thoughts of harming yourself."
        },
        new Condition
        {
            Slug = "bipolar-disorder", Name = "Bipolar Disorder", Icon = "🌗",
            Summary = "Episodes of very high energy (mania) and low mood (depression).",
            Overview = "Bipolar disorder involves distinct episodes of elevated or irritable mood and increased energy (mania or hypomania), usually alternating with depressive episodes. It is different from normal mood swings and needs professional diagnosis and long-term care.",
            Signs = new[] {
                "Manic or hypomanic: much less need for sleep, racing thoughts, unusually talkative, big plans, risky spending or behaviour",
                "Depressive: low mood, loss of interest, fatigue, hopelessness",
                "Episodes last days to weeks and are a clear change from your usual self",
                "Irritability or agitation may be more obvious than happiness" },
            Causes = new[] {
                "Strongly influenced by genetics",
                "Differences in brain chemistry and sleep-wake rhythms",
                "Stress, lack of sleep, or substance use can trigger episodes" },
            Treatment = new[] {
                "Mood-stabilising medication, prescribed by a psychiatrist. Do not stop it suddenly on your own",
                "Therapy to understand the illness and spot early warning signs",
                "Regular sleep and routine, which are especially important" },
            SelfHelp = new[] {
                "Keep a steady sleep schedule",
                "Track mood and note early warning signs",
                "Avoid alcohol and drugs",
                "Make a plan with your doctor and a trusted person for what to do if an episode starts" },
            Support = new[] {
                "Learn the warning signs and gently point out changes",
                "Encourage treatment, and stay calm and non-judgmental during episodes" },
            SeekHelp = "See a psychiatrist if you notice periods of unusually high energy and little sleep, especially alternating with low periods. During a severe episode, or if there is a risk to safety, seek urgent care."
        },
        new Condition
        {
            Slug = "adhd", Name = "ADHD", Icon = "⚡",
            Summary = "Ongoing difficulty with attention, impulse control, or restlessness.",
            Overview = "Attention-deficit/hyperactivity disorder (ADHD) is a neurodevelopmental condition. It starts in childhood and often continues into adulthood. It is not laziness or lack of intelligence. Many adults are diagnosed late.",
            Signs = new[] {
                "Difficulty staying focused, easily distracted, forgetting things",
                "Trouble organising tasks and managing time, often late or missing deadlines",
                "Restlessness or feeling constantly \"on the go\"",
                "Acting or speaking impulsively, interrupting others",
                "Intense focus on things that interest you, but struggling with boring tasks" },
            Causes = new[] {
                "Mostly genetic, with differences in how the brain regulates attention",
                "Premature birth and some early-life factors may add to risk",
                "Not caused by bad parenting or too much screen time" },
            Treatment = new[] {
                "Assessment by a qualified clinician",
                "Medication in many cases, prescribed and monitored by a doctor",
                "Behavioural strategies, coaching, and skills training",
                "Support at school or work" },
            SelfHelp = new[] {
                "Use calendars, alarms, and checklists",
                "Break tasks into small steps with short deadlines",
                "Reduce distractions while working",
                "Regular exercise and sleep help focus" },
            Support = new[] {
                "Be patient and give clear, short instructions",
                "Focus on strengths and avoid labelling as lazy" },
            SeekHelp = "Consider an assessment if these difficulties have been present since childhood and affect school, work, or relationships."
        },
        new Condition
        {
            Slug = "eating-disorders", Name = "Eating Disorders", Icon = "🍃",
            Summary = "Serious conditions involving food, body image, and eating behaviours.",
            Overview = "Eating disorders include anorexia nervosa, bulimia nervosa, binge-eating disorder, and others. They are serious mental health conditions, not lifestyle choices, and can affect people of any gender, age, or body size. Early treatment improves recovery.",
            Signs = new[] {
                "Strong fear of gaining weight or intense focus on body shape",
                "Skipping meals, rigid food rules, or eating in secret",
                "Episodes of eating a lot with a feeling of loss of control",
                "Behaviours to \"make up\" for eating",
                "Withdrawing from social events involving food",
                "Physical signs such as tiredness, dizziness, or changes in periods" },
            Causes = new[] {
                "A mix of genetics, personality traits such as perfectionism, and life stress",
                "Social pressure around appearance, dieting, or bullying",
                "Often appears alongside anxiety, depression, or trauma" },
            Treatment = new[] {
                "Specialised therapy, such as CBT-E, family-based therapy, or other approaches",
                "Medical monitoring, because eating disorders can seriously affect physical health",
                "Support from a dietitian as part of a team",
                "Care ranges from outpatient to hospital depending on how serious it is" },
            SelfHelp = new[] {
                "Reach out to a doctor or therapist early. You do not have to be \"sick enough\"",
                "Try to avoid weighing, calorie counting, and social media that makes you feel worse",
                "Tell one trusted person what you are going through" },
            Support = new[] {
                "Avoid comments about weight, food, or appearance",
                "Express concern calmly, focusing on your care for them, not on their eating",
                "Encourage them to see a professional" },
            SeekHelp = "Please speak with a doctor or mental health professional as soon as you notice these patterns. If there is fainting, chest pain, or severe weakness, seek urgent medical care."
        },
        new Condition
        {
            Slug = "psychosis-schizophrenia", Name = "Psychosis & Schizophrenia", Icon = "🌫️",
            Summary = "Losing touch with reality: hearing or seeing things others don't, or fixed false beliefs.",
            Overview = "Psychosis means experiencing reality differently, for example hallucinations or delusions. Schizophrenia is a long-term condition that includes psychosis along with other symptoms. With early treatment and ongoing support, many people recover well and live full lives.",
            Signs = new[] {
                "Hearing voices or seeing things that others do not",
                "Strong beliefs that are not shared by others, such as being watched or targeted",
                "Disorganised speech or thinking",
                "Withdrawal, flat emotions, low motivation",
                "Changes in sleep, self-care, and behaviour" },
            Causes = new[] {
                "Genetics and brain development",
                "Stress, trauma, and heavy cannabis or drug use can raise risk",
                "Can also be linked to extreme sleep loss or medical conditions" },
            Treatment = new[] {
                "Antipsychotic medication, prescribed by a psychiatrist",
                "Therapy, family support, and help with work and daily living",
                "Early intervention services improve outcomes" },
            SelfHelp = new[] {
                "Take medication as prescribed and talk to your doctor before changing anything",
                "Keep regular sleep and avoid drugs and alcohol",
                "Learn your early warning signs and share them with someone you trust" },
            Support = new[] {
                "Stay calm, do not argue with beliefs or voices, but do not agree with them either",
                "Focus on how the person feels and encourage them to see a doctor" },
            SeekHelp = "Get help promptly if someone is hearing voices, seems very confused or suspicious, or is not safe. If there is danger to them or others, call emergency services."
        },
        new Condition
        {
            Slug = "borderline-personality", Name = "Borderline Personality Disorder", Icon = "🌊",
            Summary = "Intense emotions, unstable relationships, and a shaky sense of self.",
            Overview = "Borderline personality disorder (BPD) involves emotions that feel very intense and hard to settle, often alongside fear of abandonment and difficulty in close relationships. It is closely linked to painful early experiences and is treatable. Many people improve significantly with the right therapy.",
            Signs = new[] {
                "Strong emotional reactions that change quickly",
                "Intense fear of being left or rejected",
                "Relationships that swing between closeness and conflict",
                "An unstable sense of identity, feeling empty",
                "Impulsive behaviour",
                "Self-harm or suicidal thoughts (seek help right away)" },
            Causes = new[] {
                "A mix of emotional sensitivity and difficult experiences such as neglect or abuse",
                "Family history can play a role",
                "Not a character flaw" },
            Treatment = new[] {
                "Dialectical behaviour therapy (DBT) has the strongest evidence",
                "Other specialised therapies such as mentalization-based therapy",
                "Medication may help with related symptoms but is not the main treatment" },
            SelfHelp = new[] {
                "Learn to name emotions and pause before reacting",
                "Keep a regular routine and sleep",
                "Build a list of safe people and healthy ways to cope" },
            Support = new[] {
                "Be consistent, calm, and honest about your limits",
                "Take emotions seriously without feeding conflict" },
            SeekHelp = "Seek professional help if emotions and relationships feel overwhelming. If you are thinking about harming yourself, contact emergency services or someone you trust right now."
        },
        new Condition
        {
            Slug = "substance-use", Name = "Substance Use & Addiction", Icon = "🧩",
            Summary = "When alcohol or drugs start to control your life.",
            Overview = "Addiction is a medical condition where a person continues using a substance despite harm. It is not a lack of willpower. Substance use and mental health problems often go together and can make each other worse.",
            Signs = new[] {
                "Using more or longer than planned",
                "Strong cravings, or being unable to cut down",
                "Needing more to get the same effect, or withdrawal symptoms",
                "Neglecting responsibilities or relationships",
                "Continuing despite health, legal, or money problems" },
            Causes = new[] {
                "Genetics, early exposure, and stress or trauma",
                "Using substances to cope with pain, anxiety, or low mood",
                "Environment and easy access" },
            Treatment = new[] {
                "Medical supervision for withdrawal, which can be dangerous with some substances",
                "Therapy such as CBT and motivational approaches",
                "Medication for some addictions, with a doctor",
                "Peer support groups and ongoing follow-up" },
            SelfHelp = new[] {
                "Tell a doctor or someone you trust, which is often the hardest and best first step",
                "Avoid people, places, and routines that trigger use",
                "Do not stop suddenly after heavy long-term use without medical advice" },
            Support = new[] {
                "Express concern without shaming",
                "Do not cover for consequences, and encourage professional help",
                "Look after your own wellbeing too" },
            SeekHelp = "See a doctor or addiction service if you cannot control use or it is harming your life. Seek urgent care for overdose signs such as unresponsiveness, very slow breathing, or confusion."
        },
        new Condition
        {
            Slug = "suicidal-thoughts-self-harm", Name = "Suicidal Thoughts & Self-Harm", Icon = "🤍", Urgent = true,
            Summary = "If you are thinking about ending your life or hurting yourself, you deserve support now.",
            Overview = "Thoughts of suicide or self-harm are more common than people realise, and they are a sign of deep pain, not weakness. These feelings can change, and people do get through them with support. You do not have to handle this alone.",
            Signs = new[] {
                "Talking about wanting to die, being a burden, or having no reason to live",
                "Feeling trapped, hopeless, or in unbearable pain",
                "Withdrawing from others, giving away belongings, or saying goodbye",
                "Big changes in mood, sleep, or behaviour",
                "Hurting yourself to cope with emotional pain" },
            Causes = new[] {
                "Depression and other mental health conditions",
                "Trauma, loss, bullying, abuse, or major life stress",
                "Substance use and isolation",
                "Pain that feels permanent, even when it may not be" },
            Treatment = new[] {
                "Therapies such as CBT and DBT",
                "Safety planning with a professional",
                "Treating depression, anxiety, or other related conditions",
                "Regular follow-up and support from people you trust" },
            SelfHelp = new[] {
                "If you are in danger, contact emergency services or go to the nearest emergency department",
                "Tell one person you trust how you feel, even in a few words",
                "Stay with another person and keep away from anything you could use to harm yourself",
                "Write a short safety plan: warning signs, people to call, places that feel safe",
                "Delay big decisions. Intense feelings can ease with time and support" },
            Support = new[] {
                "Ask directly and calmly: \"Are you thinking about ending your life?\". Asking does not plant the idea",
                "Listen without judgement, stay with them, and take it seriously",
                "Help them reach emergency services or a professional. Do not leave them alone if they are in immediate danger" },
            SeekHelp = "If you are in immediate danger, call emergency services now. If you are not sure, please reach out to a doctor, a mental health professional, or someone you trust today."
        },
        new Condition
        {
            Slug = "grief", Name = "Grief & Loss", Icon = "🕊️",
            Summary = "The natural but painful response to losing someone or something important.",
            Overview = "Grief is a normal response to loss. It comes in waves and looks different for everyone. There is no \"right\" way or timeline. For some people, grief stays intense and disabling for a long time (prolonged grief), and treatment can help.",
            Signs = new[] {
                "Sadness, crying, numbness, or anger",
                "Guilt, regret, or longing for the person",
                "Trouble sleeping, concentrating, or eating",
                "Feeling that life has lost its meaning for a while",
                "Physical tiredness and aches" },
            Causes = new[] {
                "Death of a loved one",
                "Other losses: a relationship, job, health, or home",
                "Sudden or traumatic losses can be harder to process" },
            Treatment = new[] {
                "Support groups and counselling",
                "Specialised therapy for prolonged grief",
                "Treatment for depression if it develops" },
            SelfHelp = new[] {
                "Let yourself feel without judging yourself",
                "Keep to basic routines, meals, and sleep",
                "Talk about the person, and lean on friends and family",
                "Be patient. Special dates may bring new waves" },
            Support = new[] {
                "Be present, listen, and say their name",
                "Avoid \"they're in a better place\" or \"you should be over it\"",
                "Offer practical help, and keep checking in after the first weeks" },
            SeekHelp = "Seek help if grief is not easing after many months, if you cannot function, or if you have thoughts of ending your life."
        },
        new Condition
        {
            Slug = "burnout-stress", Name = "Stress & Burnout", Icon = "🔥",
            Summary = "Long-term pressure that leaves you exhausted, detached, and drained.",
            Overview = "Stress is the body's response to pressure. Burnout develops after prolonged, unmanaged stress, especially related to work, study, or caring for others. It involves deep exhaustion, feeling detached, and reduced performance. It is not a personal weakness.",
            Signs = new[] {
                "Constant exhaustion that rest doesn't fix",
                "Cynicism, detachment, or dread about work or study",
                "Feeling ineffective, forgetful, or unable to concentrate",
                "Headaches, stomach problems, or frequent illness",
                "Irritability and trouble switching off" },
            Causes = new[] {
                "Excessive workload, lack of control, or lack of support",
                "Unclear expectations or constant pressure",
                "Perfectionism and difficulty saying no",
                "Caring for others with little rest" },
            Treatment = new[] {
                "Changing the sources of stress where possible: workload, boundaries, support",
                "Counselling or therapy to build coping skills",
                "Medical care if depression or anxiety develops",
                "Time off and proper rest" },
            SelfHelp = new[] {
                "Protect sleep, meals, and movement",
                "Set clear limits on work and study hours",
                "Take real breaks and spend time on things you enjoy",
                "Ask for help or delegate",
                "Try the Breathe tool on this site for a quick reset" },
            Support = new[] {
                "Offer to take something off their plate",
                "Encourage rest without making them feel guilty" },
            SeekHelp = "Talk to a professional if exhaustion lasts for weeks, affects your health, or comes with low mood, anxiety, or hopelessness."
        },
        new Condition
        {
            Slug = "postpartum-depression", Name = "Postpartum Depression", Icon = "🍼",
            Summary = "Depression or anxiety after having a baby.",
            Overview = "Many new mothers have the \"baby blues\" in the first two weeks: tearfulness and mood swings that fade. Postpartum depression is stronger, lasts longer, and can start anytime in the first year. It can also affect fathers and partners. It is common and treatable, and it is not a sign of being a bad parent.",
            Signs = new[] {
                "Persistent sadness, emptiness, or tearfulness",
                "Anxiety, panic, or constant worry about the baby",
                "Difficulty bonding, or feeling numb",
                "Extreme tiredness and trouble sleeping even when the baby sleeps",
                "Guilt or feeling like a failure",
                "Thoughts of harming yourself or the baby (seek help right away)" },
            Causes = new[] {
                "Big hormonal changes after birth",
                "Sleep deprivation and the demands of caring for a newborn",
                "Previous depression, difficult birth, or lack of support" },
            Treatment = new[] {
                "Talk therapy",
                "Medication, some of which can be used safely during breastfeeding. Ask a doctor",
                "Practical and emotional support at home" },
            SelfHelp = new[] {
                "Accept help with the baby, meals, and chores",
                "Rest when you can and keep contact with other adults",
                "Tell your doctor or midwife how you are really feeling" },
            Support = new[] {
                "Take over night feeds or chores where possible",
                "Listen without judging, and encourage them to get care" },
            SeekHelp = "Contact a doctor if low mood lasts beyond two weeks or is getting worse. If you have thoughts of harming yourself or the baby, or you feel out of touch with reality, seek urgent help immediately."
        }
    };
}